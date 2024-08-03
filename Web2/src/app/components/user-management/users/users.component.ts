import { Component, OnInit } from '@angular/core';
import { UserService } from 'app/services/user.service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  constructor(private userService: UserService){}

  ngOnInit(): void {

    this.userService.getAllUsers().subscribe(
      (response) => {
        console.log(response);
        // this.showLoading = false;
        // this.sharedService.saveSession(response);
        // this.router.navigate(['/dashboard']);
      },
      (error) => {
        // this.showLoading = false;
        // this.sharedService.showAlert('User or Pass Incorrect', 'Error');
      }
    );
  }

}
