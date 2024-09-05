import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'app/services/company.service';
import { Company } from 'app/types/company/create-company';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-company-grid',
  templateUrl: './company-grid.component.html',
  styleUrls: ['./company-grid.component.scss']
})
export class CompanyGridComponent implements OnInit {

  companyList: Company[] = [];
  private subscription: Subscription;



  constructor(private companyService: CompanyService){}

  ngOnInit(): void {

this.LoadData();
    this.companyService.getAll().subscribe(data => this.companyList = data);
  }

  LoadData(): void {
    this.subscription =  this.companyService.getAll().subscribe(x => {
      this.companyList = x;
      console.log('company', this.companyList);
    });
  }


  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

}
