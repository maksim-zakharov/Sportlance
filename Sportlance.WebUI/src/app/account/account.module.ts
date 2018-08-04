import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {AccountComponent} from './account.component';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatCheckboxModule, MatDialogModule} from '@angular/material';
import {RouterModule} from '@angular/router';
import {AccountRoutingModule} from './account-routing.module';
import {EditPhotoDialogComponent} from './edit-photo-dialog/edit-photo-dialog.component';
import {EditTrainerAboutDialogComponent} from './edit-trainer-about-dialog/edit-trainer-about-dialog.component';
import {EditTrainerPaidDialogComponent} from './edit-trainer-paid-dialog/edit-trainer-paid-dialog.component';
import {EditBackgroundDialogComponent} from './edit-background-dialog/edit-background-dialog.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    MatCheckboxModule,
    RouterModule,
    AccountRoutingModule,
    MatDialogModule
  ],
  entryComponents: [
    EditPhotoDialogComponent,
    EditTrainerAboutDialogComponent,
    EditTrainerPaidDialogComponent,
    EditBackgroundDialogComponent
  ],
  declarations: [
    AccountComponent,
    EditBackgroundDialogComponent,
    EditTrainerAboutDialogComponent,
    EditTrainerPaidDialogComponent,
    EditPhotoDialogComponent
  ]
})
export class AccountModule {
}
