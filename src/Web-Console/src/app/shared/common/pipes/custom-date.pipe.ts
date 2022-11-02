import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'customDate'
})
export class CustomDatePipe implements PipeTransform {

  transform(value: Date): string {

    console.log(value.getDate().valueOf())
    console.log(value.getMonth().valueOf())
    console.log(value.getFullYear().valueOf())
    console.log(value)
    console.log(value)
    return '';
  }

}
