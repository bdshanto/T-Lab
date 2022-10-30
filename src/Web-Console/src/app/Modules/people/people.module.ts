import { NgModule } from '@angular/core';
import { PeopleRoutingModule } from './people-routing.module';
import { PersonListComponent } from './person-list/person-list.component';
import { AddPeopleComponent } from './add-people/add-people.component';
import { PersonService } from 'src/app/services/person.service';
import { MaterialModule } from 'src/app/app.module';
import { CommonModule } from '@angular/common';
import { PipesModule } from 'src/app/shared/common/pipes/pipes.module';
import { ConfirmDialogComponent } from 'src/app/core/components/confirm-dialog/confirmation-dialog.component';
import { ConfirmationModule } from 'src/app/core/components/confirm-dialog/confirmation.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    PersonListComponent,
    AddPeopleComponent,

  ],
  imports: [
    CommonModule,
    PeopleRoutingModule,
    MaterialModule,
    PipesModule,
    ConfirmationModule,
    ReactiveFormsModule,


    // PipesModule
  ],
  entryComponents: [ConfirmDialogComponent],
  providers: [
    PersonService
  ]
})
export class PeopleModule {
}
