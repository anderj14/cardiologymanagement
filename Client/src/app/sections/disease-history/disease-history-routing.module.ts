import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { DiseaseHistoryDetailsComponent } from './disease-history-details/disease-history-details.component';

const routes: Routes = [
  { path: ':patientId/diseaseshistory/:diseasehistoryId', component: DiseaseHistoryDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class DiseaseHistoryRoutingModule { }
