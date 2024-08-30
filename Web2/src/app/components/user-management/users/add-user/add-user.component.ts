// import { Component,  } from "@angular/core";
// import { FormArray, FormBuilder, FormGroup, Validators } from "@angular/forms";
// // import { MatLegacyDialogRef as MatDialogRef } from "@angular/material/legacy-dialog";
// import { UserService } from "app/services/user.service";

// @Component({
//   selector: "app-add-user",
//   templateUrl: "./add-user.component.html",
//   styleUrls: ["./add-user.component.scss"],
// })
// export class AddUserComponent {
//   userForm: FormGroup;

//   constructor(
//     // private fb: FormBuilder,
//     // private dialogRef: MatDialogRef<AddUserComponent>,
//     // private userService: UserService
//   ) {
//   // this.userForm = this.fb.group({
//   //     identification: ["", Validators.required],
//   //     email: ["", [Validators.required, Validators.email]],
//   //     firstName: ["", Validators.required],
//   //     middleName: [""],
//   //     lastName: ["", Validators.required],
//   //     phone: [""],
//   //     password: ["", Validators.required],
//   //     addresses: this.fb.array([this.createAddressGroup()]),
//   //   });
//   // }

//   // createAddressGroup(): FormGroup {
//   //   return this.fb.group({
//   //     address: ["", Validators.required],
//   //     city: [""],
//   //     state: [""],
//   //     postalCode: [""],
//   //   });
//   // }

//   addAddress(): void {
//     this.addresses.push(this.createAddressGroup());
//   }

//   get addresses(): FormArray {
//     return this.userForm.get("addresses") as FormArray;
//   }

//   save() {
//     if (this.userForm.valid) {
//       this.userService.createUser(this.userForm.value).subscribe(
//         (response) => {
//           // Handle success response
//           console.log('User saved successfully', response);
//           this.dialogRef.close(this.userForm.value);
//         },
//         (error) => {
//           // Handle error response
//           console.error('Error saving user', error);
//         }
//       );
//     }
//   }

//   close() {
//     this.dialogRef.close();
//   }
// }
