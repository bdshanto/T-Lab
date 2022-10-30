import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { FileModelVm, PersonVm } from 'src/app/models/PersonVm';
import { PersonService } from 'src/app/services/person.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmDialogComponent } from 'src/app/core/components/confirm-dialog/confirmation-dialog.component';
import { ScrollControlService } from 'src/app/services/scroll-control.service';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.scss']
})
export class PersonListComponent implements OnInit {

  displayedColumns = ['sl', 'name', 'country', 'city', 'skills', 'resume', 'dob', 'id'];
  personList: PersonVm[] = [];
  dataSource = new MatTableDataSource<PersonVm>(this.personList);

  constructor(
    private service: PersonService,
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private scrService: ScrollControlService,
  ){

  }

  ngOnInit(): void{
    this.service.get().subscribe((res) => {
      this.personList = res
      this.dataSource = new MatTableDataSource<PersonVm>(this.personList);
    });
  }

  public getResume(resumeUrl: string): void{
    this.service.getFileById({...new FileModelVm(), fileName: resumeUrl}).subscribe((res: FileModelVm) => {
      if (res && res.base64String?.length > 0){
        let file = `data:application/${res.fileExtension};base64,` + res.base64String;
        this.showPdf(file, res.fileName);
      }
    });
  }

  showPdf(linkSource: any, fileName: string){
    const downloadLink = document.createElement('a');
    downloadLink.href = linkSource;
    downloadLink.download = fileName;
    downloadLink.click();
  }

  openDialog(){
    const confirmDialog = this.dialog.open(ConfirmDialogComponent, {
      data: {
        title: 'Confirm Remove Employee',
        message: 'Are you sure, you want to remove   '
      }
    });
    confirmDialog.afterClosed().subscribe(result => {
      if (result === true){
      }
    });
  }


}
