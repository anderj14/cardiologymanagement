import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppointmentComponent } from './appointment.component';
import { AppointmentItemComponent } from './appointment-item/appointment-item.component';
import { AppointmentDetailsComponent } from './appointment-details/appointment-details.component';
import { AppointmentRoutingModule } from './appointment-routing.module';
import { MaterialModule } from '../material/material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { DatePickerComponent } from './date-picker/date-picker.component';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    AppointmentComponent,
    AppointmentItemComponent,
    AppointmentDetailsComponent,
    DatePickerComponent
  ],
  imports: [
    CommonModule,
    AppointmentRoutingModule,
    MaterialModule,
    FormsModule,
    CoreModule,
    SharedModule,
    ReactiveFormsModule
  ]
})
export class AppointmentModule { }
