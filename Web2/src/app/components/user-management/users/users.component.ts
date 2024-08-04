import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/services/user.service';
import { UserCreate } from 'app/types/user-create';
import { User } from 'app/types/user-types-new';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
})
export class UsersComponent implements OnInit {

userList: User[] = [];


  constructor(private userService: UserService){}

  ngOnInit(): void {
    this.userService.getAllUsers().subscribe(data => this.userList = data);
  }


  



}
