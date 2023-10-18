import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiseaseHistoryModule } from './disease-history/disease-history.module';
import { MedicalHistoryModule } from './medical-history/medical-history.module';
import { AppointmentModule } from './appointment/appointment.module';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MedicalHistoryModule,
    DiseaseHistoryModule,
    AppointmentModule
  ]
})
export class SectionsModule { }
