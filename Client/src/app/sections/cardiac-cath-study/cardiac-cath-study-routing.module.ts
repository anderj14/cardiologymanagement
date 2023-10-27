import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CardiacCathStudyDetailsComponent } from './cardiac-cath-study-details/cardiac-cath-study-details.component';

const routes: Routes = [
  {path: ':patientId/cardiacCathStudies/:cardiacCathStudyId', component: CardiacCathStudyDetailsComponent}
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CardiacCathStudyRoutingModule { }
