import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ConfirmDialogComponent } from 'src/app/core/components/confirm-dialog/confirmation-dialog.component';
import { MaterialModule } from 'src/app/app.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [ConfirmDialogComponent],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  entryComponents:[ConfirmDialogComponent],
  exports:[
    ConfirmDialogComponent
  ]
})
export class ConfirmationModule { }
