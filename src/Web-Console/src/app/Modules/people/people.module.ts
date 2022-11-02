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
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PersonViewComponent } from './person-view/person-view.component';
import { MatListModule } from '@angular/material/list';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';


@NgModule({
  declarations: [
    PersonListComponent,
    AddPeopleComponent,
    PersonViewComponent,

  ],
  imports: [
    CommonModule,
    PeopleRoutingModule,
    MaterialModule,
    PipesModule,
    ConfirmationModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatDividerModule,
    MatListModule,
    FormsModule
  ],
  entryComponents: [ConfirmDialogComponent,AddPeopleComponent],
  providers: [
    PersonService
  ]
})
export class PeopleModule {
}
