import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomDatePipe } from 'src/app/shared/common/pipes/custom-date.pipe';
import { StringLimitPipe } from './string-limit.pipe';


@NgModule({
  declarations: [CustomDatePipe, StringLimitPipe],
  imports: [
    CommonModule
  ], exports: [CustomDatePipe, StringLimitPipe]
})
export class PipesModule {
}
