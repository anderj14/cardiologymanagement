import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SurgeryComponent } from './surgery.component';
import { SurgeryDetailsComponent } from './surgery-details/surgery-details.component';

const routes: Routes = [
  { path: '', component: SurgeryComponent },
  { path: ':id', component: SurgeryDetailsComponent },
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
export class SurgeryRoutingModule { }
