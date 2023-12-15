import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentComponent } from './appointment.component';
import { AppointmentItemComponent } from './appointment-item/appointment-item.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentRoutingModule } from './appointment-routing.module';



@NgModule({
  declarations: [
    AppointmentComponent,
    AppointmentItemComponent,
    AppointmentDetailsComponent
  ],
  imports: [
    CommonModule,
    AppointmentRoutingModule
  ]
})
export class AppointmentModule { }
