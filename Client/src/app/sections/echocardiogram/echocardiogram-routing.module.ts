import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EchocardiogramDetailsComponent } from './echocardiogram-details/echocardiogram-details.component';

const routes: Routes = [
  {path: ':patientId/echocardiograms/:echocardiogramId', component: EchocardiogramDetailsComponent}
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
export class EchocardiogramRoutingModule { }
