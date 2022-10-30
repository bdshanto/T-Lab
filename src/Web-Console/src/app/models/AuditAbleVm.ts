export abstract class AuditAbleVm {
  createBy: string = '';
  createOn: Date = new Date();
  updateB?: string | null;
  updateOn?: string | null;
  isDeleted: boolean = false;
  deletedBy?: string | null;
  deletedOn?: string | null;
}
