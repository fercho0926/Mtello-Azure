import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { UserService } from 'app/services/user.service';
import { User } from 'app/types/user-types-new';
import { AddUserComponent } from './add-user/add-user.component';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {

userList: User[] = [];


  constructor(private userService: UserService, private dialog: MatDialog){}

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(data => this.userList = data);
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
