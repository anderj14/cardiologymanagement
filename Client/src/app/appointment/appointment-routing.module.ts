import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { AppointmentComponent } from './appointment.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';

const route: Routes = [
  { path: '', component: AppointmentComponent },
  { path: ':id', component: AppointmentDetailsComponent },
]

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forChild(route)
  ],
  exports: [
    RouterModule
  ]
})
export class AppointmentRoutingModule { }
