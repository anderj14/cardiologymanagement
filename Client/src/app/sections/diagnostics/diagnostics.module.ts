import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiagnosticComponent } from './diagnostic.component';
import { DiagnosticDetailsComponent } from './diagnostic-details/diagnostic-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { DiagnosticRoutingModule } from './diagnostic-routing.module';



@NgModule({
  declarations: [
    DiagnosticComponent,
    DiagnosticDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    DiagnosticRoutingModule
  ],
  exports: [
  ]
})
export class DiagnosticsModule { }
