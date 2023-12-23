import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreatmentComponent } from './treatment.component';
import { TreatmentDetailsComponent } from './treatment-details/treatment-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { TreatmentRoutingModule } from './treatment-routing.module';
import { MaterialModule } from 'src/app/material/material/material.module';


@NgModule({
  declarations: [
    TreatmentComponent,
    TreatmentDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    TreatmentRoutingModule,
    MaterialModule
  ]
})
export class TreatmentModule { }
