import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { User } from 'app/types/user-types-new';
import { AddUserComponent } from './add-user/add-user.component';
import { UserService } from 'app/services/user.service';
import { MatDialog } from '@angular/material/dialog';

import * as $ from 'jquery'; // Import jQuery
import 'datatables.net'; // Import DataTables library
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ViewUserComponent } from './view-user/view-user.component';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']

})
export class UsersComponent implements OnInit  {

userList: User[] = [];
filteredData: User[] = [];
isModalOpen = false;
userIdToDelete: string | null = null;



private subscription: Subscription;
@ViewChild(MatPaginator) paginator: MatPaginator;


dataTable: any;
dataSource: MatTableDataSource<User>;



   constructor(private userService: UserService, private dialog: MatDialog, private router: Router){}

   ngOnInit(): void {
    this.loadUsers();


  }

  loadUsers(): void {
    this.userService.getAllUsers().subscribe(users => {
      this.dataSource = new MatTableDataSource(users);
    });
  }

  ngAfterViewInit() {
    if (this.dataSource) {
      this.dataSource.paginator = this.paginator;
    }
  }


  // initializeDataTable(): void {
  //   // Check if DataTable is already initialized and destroy it if so
  //   if ($.fn.DataTable.isDataTable('#userTable')) {
  //     $('#userTable').DataTable().destroy();
  //   }

  //   // Initialize DataTable
  //   this.dataTable = $('#userTable').DataTable({
  //     data: this.userList,
  //     columns: [
  //       { data: 'identification' },
  //       {
  //         data: 'firstName',
  //         render: (data, type, row) => `${data} ${row.lastName}`
  //       },
  //       { data: 'email' },
  //       {
  //         data: 'isActive',
  //         render: (data, type, row) => {
  //           return `<mat-slide-toggle class="toggle-slide" [checked]="${data}" (change)="onToggleChange($event, ${row.id})"></mat-slide-toggle>`;
  //         },
  //         orderable: false // Make the column non-orderable
  //       },
  //       {
  //         data: null,
  //         defaultContent: `
  //             <button class="btn btn-icon" matTooltip="View" [matTooltipPosition]="'above'" (click)="userDetail($event,)">
  //             <i class="material-icons">visibility</i>
  //           </button>
  //           <button class="btn btn-icon" matTooltip="Edit" [matTooltipPosition]="'above'" (click)="editUser(event)">
  //             <i class="material-icons">edit</i>
  //           </button>
  //           <button class="btn btn-icon" matTooltip="Remove" [matTooltipPosition]="'above'" (click)="removeUser(event)">
  //             <i class="material-icons">delete</i>
  //           </button>
  //         `
  //       }
  //     ]
  //   });
  // }




  applyFilter(filterValue: string): void {

// this.userList.filter = filterValue.trim().toLowerCase();

     this.dataSource.filter = filterValue.trim().toLowerCase();
  }
  
  



  addDialog() {
    const dialogRef = this.dialog.open(AddUserComponent, {
      disableClose :true,
        width: '800px',
       data: {  editMode: false },

    })
    .afterClosed()
    .subscribe((result) => {
      if (result) {
        this.loadUsers();
      }
    });
  }

  editDialog(userId :string) {
    this.dialog.open(AddUserComponent, {
      width: '800px',
      data: { userId: userId, editMode: true },
    });
  }

  UserDetailss(userId: string) {
    this.dialog.open(ViewUserComponent, {
      data: { userId: userId },
      width: '800px'
    });
  }

  UserDetails(userId: string) {
    this.dialog.open(AddUserComponent, {
      data: { userId: userId, viewMode: true },
      width: '800px'
    });
  }



  openConfirmModal(userId: string): void {
    this.userIdToDelete = userId;
    this.isModalOpen = true;
  }

  closeConfirmModal(): void {
    this.isModalOpen = false;
    this.userIdToDelete = null;
  }

  confirmDelete(): void {
    if (this.userIdToDelete) {
      this.DeleteUser(this.userIdToDelete);
      this.closeConfirmModal();
    }
  }


  DeleteUser(userId :string){

    this.subscription = this.userService.deleteById(userId).subscribe();


  }


  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
  












}
