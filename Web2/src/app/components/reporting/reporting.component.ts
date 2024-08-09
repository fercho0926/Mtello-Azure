import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Import Router
import { BatchPaycheck } from 'app/types/report/batch-paycheck';
import { ReportService } from '../../services/report.service';


@Component({
  selector: 'app-reporting',
  templateUrl: './reporting.component.html',
  styleUrls: ['./reporting.component.scss']
})
export class ReportingComponent implements OnInit {

  batchList: BatchPaycheck[] = [];


  constructor(private router: Router , private reportService : ReportService) { } // Inject Router


  ngOnInit(): void {
  
    this.reportService.GetAllBatchPayChecks().subscribe(data => this.batchList = data);

  }

  details(): void {
    let reportingId = 1;
    this.router.navigate(['/reporting-details', reportingId]);
  }

}



