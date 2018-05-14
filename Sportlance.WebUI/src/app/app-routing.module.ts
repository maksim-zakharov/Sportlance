import {Paths} from './paths';
import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {RootComponent} from './components/root/root.component';
import {TrainersComponent} from './components/trainers/trainers.component';
import {LandingComponent} from './components/landing/landing.component';
import {ProfileComponent} from './components/profile/profile.component';
import {SignupComponent} from './components/signup/signup.component';
import {LoginComponent} from './components/login/login.component';
import {ConfirmRegisterComponent} from './components/confirm-register/confirm-register.component';
import {InitializationComponent} from './components/initialization/initialization.component';
import {InitializationGuard} from './guards/initialization.guard';
import {AccountComponent} from './components/account/account.component';
import {EmailVerifyComponent} from './components/email-verify/email-verify.component';
import {EmailConfirmationGuard} from './guards/email-confirmation-guard';

const appRoutes: Routes = [
  {path: Paths.Initialization, component: InitializationComponent},
  {
    path: Paths.Root, component: RootComponent, canActivate: [InitializationGuard], children: [
    {path: Paths.Root, pathMatch: 'full', component: LandingComponent},
    {path: Paths.Trainers, pathMatch: 'full', component: TrainersComponent},
    {path: Paths.Trainers + '/:id', pathMatch: 'full', component: TrainersComponent},
    {path: Paths.Profile + '/:id', pathMatch: 'full', component: ProfileComponent},
    {path: Paths.Account, pathMatch: 'full', component: AccountComponent}
  ]
  },
  {path: Paths.SignUp, pathMatch: 'full', component: SignupComponent},
  {path: Paths.EmailVerify, pathMatch: 'full', component: EmailVerifyComponent, canActivate: [EmailConfirmationGuard]},
  {path: Paths.ConfirmRegistration, component: ConfirmRegisterComponent},
  {path: Paths.Login, pathMatch: 'full', component: LoginComponent},
  {path: '**', redirectTo: Paths.Root}
];

@NgModule({
  imports: [
    RouterModule.forRoot(appRoutes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule {
}
