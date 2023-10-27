import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BloodTestDetailsComponent } from './blood-test-details/blood-test-details.component';

const routes: Routes = [
  { path: ':patientId/bloodTests/:bloodTestId', component: BloodTestDetailsComponent },
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class BloodTestRoutingModule { }
