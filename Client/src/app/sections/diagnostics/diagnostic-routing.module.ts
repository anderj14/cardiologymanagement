import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DiagnosticDetailsComponent } from './diagnostic-details/diagnostic-details.component';

const routes: Routes = [
  { path: ':patientId/diagnostics/:diagnosticId', component: DiagnosticDetailsComponent }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class DiagnosticRoutingModule { }
