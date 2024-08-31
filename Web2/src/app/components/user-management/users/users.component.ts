import { AfterViewInit, Component, OnInit } from '@angular/core';
import { User } from 'app/types/user-types-new';
import { AddUserComponent } from './add-user/add-user.component';
import { UserService } from 'app/services/user.service';
import { MatDialog } from '@angular/material/dialog';

import * as $ from 'jquery'; // Import jQuery
import 'datatables.net'; // Import DataTables library


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit, AfterViewInit  {

userList: User[] = [];

dataTable: any;


   constructor(private userService: UserService, private dialog: MatDialog){}

   ngOnInit(): void {
    // Fetch users from the service
    this.userService.getAllUsers().subscribe(data => {
      this.userList = data;
      this.initializeDataTable(); // Initialize DataTable after data is fetched
    });
  }


  initializeDataTable(): void {
    // Check if DataTable is already initialized and destroy it if so
    if ($.fn.DataTable.isDataTable('#userTable')) {
      $('#userTable').DataTable().destroy();
    }

    // Initialize DataTable
    this.dataTable = $('#userTable').DataTable({
      data: this.userList,
      columns: [
        { data: 'identification' },
        {
          data: 'firstName',
          render: (data, type, row) => `${data} ${row.lastName}`
        },
        { data: 'email' },
        {
          data: 'isActive',
          render: (data, type, row) => {
            return `<mat-slide-toggle class="toggle-slide" [checked]="${data}" (change)="onToggleChange($event, ${row.id})"></mat-slide-toggle>`;
          },
          orderable: false // Make the column non-orderable
        },
        {
          data: null,
          defaultContent: `
              <button class="btn btn-icon" matTooltip="View" [matTooltipPosition]="'above'" (click)="viewUser(event)">
              <i class="material-icons">visibility</i>
            </button>
            <button class="btn btn-icon" matTooltip="Edit" [matTooltipPosition]="'above'" (click)="editUser(event)">
              <i class="material-icons">edit</i>
            </button>
            <button class="btn btn-icon" matTooltip="Remove" [matTooltipPosition]="'above'" (click)="removeUser(event)">
              <i class="material-icons">delete</i>
            </button>
          `
        }
      ]
    });
  }


  ngAfterViewInit(): void {
    // Initialize DataTables after the view is initialized
    $(document).ready(function() {
    });
  } 
  
  



  openDialog() {
    const dialogRef = this.dialog.open(AddUserComponent, {
      // width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Handle the result, e.g., save the user data
        console.log('User data:', result);
      }
    });
  }

  



}
