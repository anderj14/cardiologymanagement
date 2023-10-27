import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedicalHistoryDetailsComponent } from './medical-history-details/medical-history-details.component';

const routes: Routes = [
  {path: ':patientId/medicalhistories/:medicalhistoryId', component: MedicalHistoryDetailsComponent}
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
export class MedicalHistoryRoutingModule { }
