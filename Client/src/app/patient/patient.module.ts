import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientComponent } from './patient.component';
import { CoreModule } from '../core/core.module';
import { PatientItemComponent } from './patient-item/patient-item.component';
import { SharedModule } from '../shared/shared.module';
import { PatientDetailsComponent } from './patient-details/patient-details.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    PatientComponent,
    PatientItemComponent,
    PatientDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule,
    RouterModule
  ],
  exports: [
    PatientComponent
  ]
})
export class PatientModule { }
