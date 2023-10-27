import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentComponent } from './appointment.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentRoutingModule } from './appointment-routing.module';
import { CoreModule } from 'src/app/core/core.module';



@NgModule({
  declarations: [
    AppointmentComponent,
    AppointmentDetailsComponent
  ],
  imports: [
    CommonModule,
    AppointmentRoutingModule,
    CoreModule
  ]
})
export class AppointmentModule { }
