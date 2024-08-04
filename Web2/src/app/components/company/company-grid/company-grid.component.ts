import { Component, OnInit } from '@angular/core';
import { CompanyService } from 'app/services/company.service';
import { Company } from 'app/types/company/create-company';

@Component({
  selector: 'app-company-grid',
  templateUrl: './company-grid.component.html',
  styleUrls: ['./company-grid.component.scss']
})
export class CompanyGridComponent implements OnInit {

  companyList: Company[] = [];


  constructor(private companyService: CompanyService){}

  ngOnInit(): void {
    this.companyService.getAll().subscribe(data => this.companyList = data);
  }

}
