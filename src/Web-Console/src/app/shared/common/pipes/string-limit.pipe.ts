import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'stringLimit'
})
export class StringLimitPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any{
    const limit = (args[0] && typeof (args[0] === 'number')) ? args[0] : 30;
    if (value && value.length > (limit + 4)){
      return `${value.substr(0, limit)} ...`;
    } else{
      return value;
    }
  }

}
