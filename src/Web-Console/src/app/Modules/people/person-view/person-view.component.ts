import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { PersonVm } from 'src/app/models/PersonVm';

@Component({
  selector: 'app-person-view',
  templateUrl: './person-view.component.html',
  styleUrls: ['./person-view.component.scss']
})
export class PersonViewComponent implements OnInit {

  constructor(
    private matDialogRef: MatDialogRef<PersonViewComponent>,
    @Inject(MAT_DIALOG_DATA) public data: PersonVm,
  ){
  }

  ngOnInit(): void{
  }

}
