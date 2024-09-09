import { Component, Inject,  } from "@angular/core";
import { AbstractControl, FormArray, FormBuilder, FormGroup, ValidatorFn, Validators } from "@angular/forms";
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
  isEditMode: boolean;
  isViewMode: boolean;

  private subscription: Subscription;


  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<AddUserComponent>,
    private userService: UserService,

    @Inject(MAT_DIALOG_DATA) public data: any

  ) {


    this.isEditMode = !!data.editMode;
    this.isViewMode = !!data.viewMode;

    this.loadForm();

    if (this.isEditMode || this.isViewMode) {

      this.subscription = this.userService.getById(this.data.userId).subscribe(user => {
        this.userForm.patchValue(user);
      });
    }



  }

  loadForm(): void {


    this.userForm = this.fb.group({
        email: ["", [Validators.required, Validators.email]],
        firstName: ['', [Validators.required, this.noSpecialCharsValidator()]],
        middleName: ["", [this.noSpecialCharsValidator()]],
        lastName: ["",  [Validators.required,this.noSpecialCharsValidator()]],
        phone: ["", [Validators.pattern("^[0-9]*$")]], // Added pattern validation

        password: ['', [
          Validators.required, 
          Validators.minLength(8), 
          Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[a-zA-Z\\d]{8,}')
        ]],
        addressList: this.fb.array([this.createAddressGroup()]),
      });


      // if (this.isViewMode) {
      //   this.userForm.disable(); 
      // }

  }

  createAddressGroup = (): FormGroup => {
    return this.fb.group({
      addressLine: ["", Validators.required],
      city: [""],
      state: [""],
      postalCode: [""],
    });
  }

  addAddress(): void {

    if (this.addressList.length < 2) { // Limit to a maximum of 2 addresses
      this.addressList.push(this.createAddressGroup());
    } 
  }

  get addressList(): FormArray {
    return this.userForm.get("addressList") as FormArray;
  }

  removeAddress(index: number) {
    if (this.addressList.length > 1) {
      this.addressList.removeAt(index);
    } else {
      console.log('Cannot remove the last address');
    }
  }



 save() {
    if (this.userForm.valid) {
      const userAction = this.isEditMode ? 'updateUser' : 'createUser';
      this.userService[userAction](this.userForm.value).subscribe(
        response => {
          console.log(`User ${this.isEditMode ? 'updated' : 'created'} successfully`, response);
          this.dialogRef.close(this.userForm.value);
        },
        error => {
          console.error(`Error ${this.isEditMode ? 'updating' : 'creating'} user`, error);
        }
      );
    }
  }


// Custom Validator Function
noSpecialCharsValidator(): ValidatorFn {
  return (control: AbstractControl): {[key: string]: any} | null => {
    const forbidden = /[^a-zA-Z0-9\s]/.test(control.value);
    return forbidden ? { 'noSpecialChars': { value: control.value } } : null;
  };
}

  onKeydown(event: KeyboardEvent) {
    if (event.key === 'Enter') {
      event.preventDefault(); 
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
