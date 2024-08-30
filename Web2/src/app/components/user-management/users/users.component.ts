import { Component, OnInit } from '@angular/core';
import { User } from 'app/types/user-types-new';
import { AddUserComponent } from './add-user/add-user.component';
import { UserService } from 'app/services/user.service';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {

userList: User[] = [];


   constructor(private userService: UserService, private dialog: MatDialog){}

  ngOnInit(): void {
    console.log("UsersComponent ngOnInit");
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
