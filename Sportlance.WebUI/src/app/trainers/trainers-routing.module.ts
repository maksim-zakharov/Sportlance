import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {TrainerListComponent} from './trainer-list/trainer-list.component';
import {TrainerDetailsComponent} from './trainer-details/trainer-details.component';
import {AppointmentComponent} from './appointment/appointment.component';
import {RedirectTrainerProfileResolver} from './trainer-details/redirect-trainer-profile.resolver';

const routes: Routes = [
  {path: '', component: TrainerListComponent},
  {path: ':id', component: TrainerDetailsComponent, resolve: {profile: RedirectTrainerProfileResolver}},
  {path: ':id/appointment', component: AppointmentComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class TrainersRoutingModule {
}
