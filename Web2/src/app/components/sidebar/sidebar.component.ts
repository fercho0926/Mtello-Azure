import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";
import { AuthGuard } from "app/_guards/auth.guard";
import { SharedService } from "app/shared/services/shared.service";

declare const $: any;

export const ROUTES = [
  {
    path: "/dashboard",
    title: "Dashboard",
    icon: "dashboard",
    class: "",
    canActivate: [AuthGuard],
  },
  {
    path: "/checks",
    title: "PayChecks",
    icon: "payments",
    class: "",
    canActivate: [AuthGuard],
  },
  // { path: '/user-profile', title: 'User Profile',  icon:'person', class: '' },
  // { path: '/table-list', title: 'Table List',  icon:'content_paste', class: '' },
  // { path: '/typography', title: 'Typography',  icon:'library_books', class: '' },
  // { path: '/icons', title: 'Icons',  icon:'bubble_chart', class: '' },
  // { path: '/maps', title: 'Maps',  icon:'location_on', class: '' },
  // { path: '/notifications', title: 'Notifications',  icon:'notifications', class: '' },
  { path: "/upgrade", title: "Module", icon: "unarchive", class: "active-pro" },
  {
    path: "/user-management",
    title: "User Management",
    icon: "person",
    class: "",
  },
  { path: "/reporting", title: "Reporting", icon: "summarize", class: "" },
  { path: "/company", title: "Companies", icon: "apartment", class: "" },
];

@Component({
  selector: "app-sidebar",
  templateUrl: "./sidebar.component.html",
  styleUrls: ["./sidebar.component.css"],
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  userEmail: string;

  constructor(private sharedService: SharedService, private router: Router) {}

  ngOnInit() {
    this.menuItems = ROUTES.filter((menuItem) => menuItem);

    const userToken = this.sharedService.getSession();
    if (userToken != null) {
      this.userEmail = userToken.email;
    }
  }
  isMobileMenu() {
    if ($(window).width() > 991) {
      return false;
    }
    return true;
  }

  closeSession() {
    this.sharedService.deleteSession();
    void this.router.navigate(["/login"]);
  }
}
