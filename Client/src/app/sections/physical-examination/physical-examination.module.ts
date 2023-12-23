import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PhysicalExaminationComponent } from './physical-examination.component';
import { PhysicalExaminationDetailsComponent } from './physical-examination-details/physical-examination-details.component';
import { RouterModule } from '@angular/router';
import { CoreModule } from 'src/app/core/core.module';
import { PhysicalExaminationRoutingModule } from './physical-examination-routing.module';
import { MaterialModule } from 'src/app/material/material/material.module';



@NgModule({
  declarations: [
    PhysicalExaminationComponent,
    PhysicalExaminationDetailsComponent
  ],
  imports: [
    CommonModule,
    PhysicalExaminationRoutingModule,
    CoreModule,
    MaterialModule
  ]
})
export class PhysicalExaminationModule { }
