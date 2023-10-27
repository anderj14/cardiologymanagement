import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StressTestDetailsComponent } from './stress-test-details/stress-test-details.component';

const routes: Routes = [
  { path: ':patientId/stresstests/:stresstestId', component: StressTestDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class StressTestRoutingModule { }
