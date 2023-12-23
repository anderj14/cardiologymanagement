import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MedicalHistoryComponent } from './medical-history.component';
import { RouterModule } from '@angular/router';
import { MedicalHistoryDetailsComponent } from './medical-history-details/medical-history-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { MedicalHistoryRoutingModule } from './medical-history-routing.module';
import { MaterialModule } from 'src/app/material/material/material.module';



@NgModule({
  declarations: [
    MedicalHistoryComponent,
    MedicalHistoryDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    MedicalHistoryRoutingModule,
    MaterialModule
  ]
})
export class MedicalHistoryModule { }
