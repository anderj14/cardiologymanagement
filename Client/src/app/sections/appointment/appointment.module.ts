import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentComponent } from './appointment.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';



@NgModule({
  declarations: [
    AppointmentComponent,
    AppointmentDetailsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class AppointmentModule { }
