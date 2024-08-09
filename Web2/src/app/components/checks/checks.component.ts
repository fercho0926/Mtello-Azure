import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormControl, FormGroupDirective, NgForm, Validators} from '@angular/forms';

import {ErrorStateMatcher} from '@angular/material/core';
import { CompanyService } from 'app/services/company.service';
import { Company } from 'app/types/company/create-company';

import { HttpClient } from '@angular/common/http';





/** Error when invalid control is dirty, touched, or submitted. */
export class MyErrorStateMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
    const isSubmitted = form && form.submitted;
    return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  }
}



@Component({
  selector: 'app-checks',
  templateUrl: './checks.component.html',
  styleUrls: ['./checks.component.scss']
})





  export class ChecksComponent implements OnInit {




    companyList: Company[] = [];

    selectedFile: File | null = null;


    constructor(private _formBuilder: FormBuilder, private companyService: CompanyService, private http: HttpClient) {}



    ngOnInit(): void {
      this.companyService.getAll().subscribe(data => this.companyList = data);
    }






    selected = new FormControl('valid', [Validators.required, Validators.pattern('valid')]);

    selectFormControl = new FormControl('valid', [Validators.required, Validators.pattern('valid')]);
  
    nativeSelectFormControl = new FormControl('valid', [
      Validators.required,
      Validators.pattern('valid'),
    ]);
  
    matcher = new MyErrorStateMatcher();



    firstFormGroup = this._formBuilder.group({
      firstCtrl: ['', Validators.required],
    });
    secondFormGroup = this._formBuilder.group({
      secondCtrl: ['', Validators.required],
    });
    isEditable = false;
  


    // onFileSelected(event) {
    //   const file = event.target.files[0];
    //   if (file) {
    //     // You can now do something with the file, like appending it to FormData or reading its contents
    //     // For example, to set it as the value of a form control:
    //     this.secondFormGroup.patchValue({
    //       secondCtrl: file // Assuming you want to store the file in the 'secondCtrl' form control
    //     });
    //     // If you need to manually trigger validation or update the form state, you might need to call updateValueAndValidity()
    //     this.secondFormGroup.get('secondCtrl').updateValueAndValidity();
    //   }
    // }










// new logic for file upload


    onFileSelected(event: any) {
      this.selectedFile = event.target.files[0];
    }


    uploadFile() {
      if (this.selectedFile) {
        const formData = new FormData();
        formData.append('file', this.selectedFile, this.selectedFile.name);
  
        // this.http.post('http://localhost:5023/api/Paycheck/upload', formData)
        this.http.post('https://api-scylla-pdn2.azurewebsites.net/api/Paycheck/upload', formData)
          .subscribe(response => {
            console.log('File uploaded successfully', response);
          }, error => {
            console.error('Error uploading file', error);
          });
      } else {
        console.error('No file selected');
      }
    }



  }
