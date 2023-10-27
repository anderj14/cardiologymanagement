import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MedicalHistoryComponent } from './medical-history.component';
import { RouterModule } from '@angular/router';
import { MedicalHistoryDetailsComponent } from './medical-history-details/medical-history-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { MedicalHistoryRoutingModule } from './medical-history-routing.module';



@NgModule({
  declarations: [
    MedicalHistoryComponent,
    MedicalHistoryDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    MedicalHistoryRoutingModule
  ]
})
export class MedicalHistoryModule { }
