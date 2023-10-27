import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ElectrocardiogramDetailsComponent } from './electrocardiogram-details/electrocardiogram-details.component';

const routes: Routes = [
  { path: ':patientId/electrocardiograms/:electrocardiogramId', component: ElectrocardiogramDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class ElectrocardiogramRoutingModule { }
