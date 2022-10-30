import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PersonListComponent } from 'src/app/Modules/people/person-list/person-list.component';
import { AddPeopleComponent } from 'src/app/Modules/people/add-people/add-people.component';
const routes: Routes = [
  {path: '', component: PersonListComponent},
  {path: 'edit/:id', component: AddPeopleComponent},
  {path: 'create', component: AddPeopleComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PeopleRoutingModule {
}
