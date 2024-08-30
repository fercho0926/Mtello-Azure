import { NgModule } from "@angular/core";
// import { CommonModule } from "@angular/common";


import {MatCardModule} from '@angular/material/card';
import {MatDividerModule} from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import {MatIconModule} from '@angular/material/icon';
import {MatStepperModule} from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatTooltipModule } from '@angular/material/tooltip';
import { MatTableModule } from '@angular/material/table';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSlideToggleModule } from '@angular/material/slide-toggle';






@NgModule({
  declarations: [],
  imports: [

  ],
  exports: [
    MatCardModule,
    MatDividerModule,
    MatFormFieldModule,
    MatIconModule,
    MatStepperModule, 
    MatButtonModule,
    MatInputModule,
    MatTooltipModule,
    MatTableModule,
    MatSnackBarModule,
    MatDialogModule,
    MatSlideToggleModule,
  ],
})
export class MaterialModule {}
