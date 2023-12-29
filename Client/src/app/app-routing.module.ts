
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { AuthGuard } from './core/guards/auth.guard';

const routes: Routes = [
  { path: '', component: HomePageComponent },
  { path: 'test-error', component: TestErrorComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { 
    path: 'patients', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./patient/patient.module').then(m => m.PatientModule) 
  },
  { path: 'appointments', loadChildren: () => import('./appointment/appointment.module').then(m => m.AppointmentModule) },
  { path: 'surgeries', loadChildren: () => import('./surgery/surgery.module').then(m => m.SurgeryModule) },
  { path: 'notes', loadChildren: () => import('./notes/notes.module').then(m => m.NotesModule) },
  { path: 'account', loadChildren: () => import('./account/account.module').then(m => m.AccountModule) },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

