import { Component, Inject,  } from "@angular/core";
import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
// import { MatLegacyDialogRef as MatDialogRef } from "@angular/material/legacy-dialog";
import { UserService } from "app/services/user.service";
import { Subscription } from "rxjs";

@Component({
  selector: "app-add-user",
  templateUrl: "./add-user.component.html",
  styleUrls: ["./add-user.component.scss"],
})
export class AddUserComponent {
  userForm: FormGroup;
  userId: string;
  private subscription: Subscription;


  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<AddUserComponent>,
    private userService: UserService,

    @Inject(MAT_DIALOG_DATA) public data: any

  ) {
    // this.userId = data.userId;
    console.log('userID', this.data);




    this.loadForm();

    if(this.data.editMode){
      this.subscription = this.userService.getById(this.data.userId).subscribe(user => {
        this.userForm.patchValue(user);
      });
    }



  }

  loadForm(): void {


    this.userForm = this.fb.group({
      identification: ["", Validators.required],
        email: ["", [Validators.required, Validators.email]],
        firstName: ["", Validators.required],
        middleName: [""],
        lastName: ["", Validators.required],
        phone: [""],
        password: ["", Validators.required],
        addresses: this.fb.array([this.createAddressGroup()]),
      });

  }

  createAddressGroup = (): FormGroup => {
    return this.fb.group({
      address: ["", Validators.required],
      city: [""],
      state: [""],
      postalCode: [""],
    });
  }

  addAddress(): void {
    this.addresses.push(this.createAddressGroup());
  }

  get addresses(): FormArray {
    return this.userForm.get("addresses") as FormArray;
  }

  save() {
    if (this.userForm.valid) {
      this.userService.createUser(this.userForm.value).subscribe(
        (response) => {
          // Handle success response
          console.log('User saved successfully', response);
          this.dialogRef.close(this.userForm.value);
        },
        (error) => {
          // Handle error response
          console.error('Error saving user', error);
        }
      );
    }
  }

  onKeydown(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      event.stopPropagation();
    }
  }

  close() {
    this.dialogRef.close();
  }

  ngOnDestroy(): void {
    if (this.subscription) {
      this.subscription.unsubscribe();
    }
  }

}
