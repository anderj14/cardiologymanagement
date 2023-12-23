import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DiseaseHistoryDetailsComponent } from './disease-history-details/disease-history-details.component';
import { DiseaseHistoryComponent } from './disease-history.component';
import { CoreModule } from 'src/app/core/core.module';
import { DiseaseHistoryRoutingModule } from './disease-history-routing.module';
import { MaterialModule } from 'src/app/material/material/material.module';



@NgModule({
  declarations: [
    DiseaseHistoryDetailsComponent,
    DiseaseHistoryComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    DiseaseHistoryRoutingModule,
    MaterialModule
  ]
})
export class DiseaseHistoryModule { }
