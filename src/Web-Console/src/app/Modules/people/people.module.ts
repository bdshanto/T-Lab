import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PeopleRoutingModule } from './people-routing.module';
import { PersonListComponent } from './person-list/person-list.component';
import { AddPeopleComponent } from './add-people/add-people.component';


@NgModule({
  declarations: [
    PersonListComponent,
    AddPeopleComponent
  ],
  imports: [
    CommonModule,
    PeopleRoutingModule
  ]
})
export class PeopleModule { }
