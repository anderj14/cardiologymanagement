import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PatientComponent } from './patient.component';
import { CoreModule } from '../core/core.module';
import { PatientItemComponent } from './patient-item/patient-item.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    PatientComponent,
    PatientItemComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    SharedModule
  ],
  exports: [
    PatientComponent
  ]
})
export class PatientModule { }
