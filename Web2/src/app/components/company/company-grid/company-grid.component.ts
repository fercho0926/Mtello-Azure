import { Component, OnInit } from "@angular/core";
import { CompanyService } from "app/services/company.service";
import { Subscription } from "rxjs";
import { CompanyResponse } from "app/types/company/company-response";

@Component({
  selector: "app-company-grid",
  templateUrl: "./company-grid.component.html",
  styleUrls: ["./company-grid.component.scss"],
})
export class CompanyGridComponent implements OnInit {
  companyList: CompanyResponse[] = [];
  private subscription: Subscription;

  constructor(private companyService: CompanyService) {}

  ngOnInit(): void {
    this.LoadData();
  }

  LoadData(): void {
    this.subscription = this.companyService.getAll().subscribe((x) => {
      this.companyList = x;
      console.log("company", this.companyList);
    });
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
