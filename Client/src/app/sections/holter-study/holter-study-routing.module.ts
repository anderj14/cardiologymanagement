import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HolterStudyDetailsComponent } from './holter-study-details/holter-study-details.component';

const routes: Routes = [
  {path: ':patientId/holterstudies/:holterstudyId', component: HolterStudyDetailsComponent}
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class HolterStudyRoutingModule { }
