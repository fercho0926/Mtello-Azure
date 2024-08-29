import { Injectable } from "@angular/core";
import { Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from "@angular/router";
import { Observable } from "rxjs";
import { SharedService } from "../shared/services/shared.service";

@Injectable({
  providedIn: "root",
})
export class AuthGuard  {
  constructor(private sharedService: SharedService, private router: Router) {}

  canActivate():
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    const userToken = this.sharedService.getSession();
    if (userToken) {
      return true;
    } else {
      void this.router.navigate(["login"]);
      return false;
    }
  }
}
