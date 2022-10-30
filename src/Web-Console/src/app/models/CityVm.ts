import { AuditAbleVm } from 'src/app/models/AuditAbleVm';

export class CityVm extends AuditAbleVm {
  id: number = 0;
  name: string = '';
  countryId: number = 0;
  countryName: string = '';
}
