import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientComponent } from './patient.component';
import { CoreModule } from '../core/core.module';
import { PatientItemComponent } from './patient-item/patient-item.component';
import { SharedModule } from '../shared/shared.module';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { PatientRoutingModule } from './patient-routing.module';
import { SectionsModule } from '../sections/sections.module';
import { MaterialModule } from '../material/material/material.module';
import { EditPatientComponent } from './edit-patient/edit-patient.component';
import { EditPatientFormComponent } from './edit-patient-form/edit-patient-form.component';


@NgModule({
  declarations: [
    PatientComponent,
    PatientItemComponent,
    PatientDetailsComponent,
    EditPatientComponent,
    EditPatientFormComponent,
  ],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule,
    PatientRoutingModule,
    SectionsModule,
    MaterialModule
  ]
})
export class PatientModule { }
