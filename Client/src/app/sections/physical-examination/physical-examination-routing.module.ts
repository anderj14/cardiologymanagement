import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { PhysicalExaminationDetailsComponent } from './physical-examination-details/physical-examination-details.component';

const routes: Routes = [
  {path: ':patientId/physicalexaminations/:physicalexaminationId', component: PhysicalExaminationDetailsComponent}
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
export class PhysicalExaminationRoutingModule { }
