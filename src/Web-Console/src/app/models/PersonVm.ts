import { AuditAbleVm } from 'src/app/models/AuditAbleVm';
import { SkillPersonMapVm } from 'src/app/models/SkillPersonMapVm';

export class PersonVm extends AuditAbleVm {
  id: number = 0;
  name: string = '';
  cityId? = null;
  cityName: string = '';
  countryId? = null;
  countryName: string = '';
  resumeUrl: string = '';
  resumeFile?: File;
  doB?: Date;
  skills: string = '';
  skillPersonMapList: SkillPersonMapVm[] = [];
  skillIds: number[] = [];
}

export class FileModelVm {
  fileName: string = '';
  fileExtension: string = '';
  base64String: string = '';
  status: number = 0;
}
