import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Import Router


@Component({
  selector: 'app-reporting',
  templateUrl: './reporting.component.html',
  styleUrls: ['./reporting.component.scss']
})
export class ReportingComponent implements OnInit {

  constructor(private router: Router) { } // Inject Router


  ngOnInit(): void {
  }

  details(): void {
    let reportingId = 1;
    this.router.navigate(['/reporting-details', reportingId]);
  }

}
