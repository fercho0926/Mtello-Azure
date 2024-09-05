import { Component, Inject, OnInit } from "@angular/core";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import { ActivatedRoute } from "@angular/router";
import { UserService } from "app/services/user.service";
import { User } from "app/types/user-types-new";
import { Subscription } from "rxjs";

@Component({
  selector: "app-view-user",
  templateUrl: "./view-user.component.html",
  styleUrls: ["./view-user.component.scss"],
})
export class ViewUserComponent implements OnInit {
  private subscription: Subscription;

  userDetails: User;
  isLoading: boolean = true;


  constructor(
    private userService: UserService,
    public dialogRef: MatDialogRef<ViewUserComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  ngOnInit(): void {
    this.getUserBydId(this.data.userId);
  }

  getUserBydId(id: string): void {
    this.subscription = this.userService.getById(id).subscribe((x) => {
      this.userDetails = x;
    });

    this.isLoading = false;

  }


  close(): void {
    this.dialogRef.close("true");
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }
}
