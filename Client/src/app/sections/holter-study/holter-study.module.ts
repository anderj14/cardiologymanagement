import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HolterStudyComponent } from './holter-study.component';
import { HolterStudyDetailsComponent } from './holter-study-details/holter-study-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { HolterStudyRoutingModule } from './holter-study-routing.module';
import { MaterialModule } from 'src/app/material/material/material.module';



@NgModule({
  declarations: [
    HolterStudyComponent,
    HolterStudyDetailsComponent
  ],
  imports: [
    CommonModule,
    HolterStudyRoutingModule,
    CoreModule,
    MaterialModule
  ]
})
export class HolterStudyModule { }
