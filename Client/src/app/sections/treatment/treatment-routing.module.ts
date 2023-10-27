import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TreatmentDetailsComponent } from './treatment-details/treatment-details.component';

const routes: Routes = [
  {path: ':patientId/treatments/:treatmentId', component: TreatmentDetailsComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class TreatmentRoutingModule { }
