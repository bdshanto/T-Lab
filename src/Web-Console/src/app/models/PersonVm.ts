import { AuditAbleVm } from 'src/app/models/AuditAbleVm';
import { SkillPersonMapVm } from 'src/app/models/SkillPersonMapVm';

export class PersonVm extends AuditAbleVm {
  id: number = 0;
  name: string = '';
  cityId: number = 0;
  cityName: string = '';
  countryId: number = 0;
  countryName: string = '';
  resumeUrl: string = '';
  resumeFile?: File;
  doB?: Date;
  skills: string = '';
  skillPersonMapList: SkillPersonMapVm[] = [];
}

export class FileModelVm {
  fileName: string = '';
  fileExtension: string = '';
  base64String: string = '';
  status: number = 0;
}
