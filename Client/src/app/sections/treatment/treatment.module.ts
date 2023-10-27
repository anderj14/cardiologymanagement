import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TreatmentComponent } from './treatment.component';
import { TreatmentDetailsComponent } from './treatment-details/treatment-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { TreatmentRoutingModule } from './treatment-routing.module';


@NgModule({
  declarations: [
    TreatmentComponent,
    TreatmentDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    TreatmentRoutingModule
  ]
})
export class TreatmentModule { }
