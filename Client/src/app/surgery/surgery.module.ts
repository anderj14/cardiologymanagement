import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SurgeryComponent } from './surgery.component';
import { SurgeryItemComponent } from './surgery-item/surgery-item.component';
import { SurgeryDetailsComponent } from './surgery-details/surgery-details.component';
import { SurgeryRoutingModule } from './surgery-routing.module';
import { MaterialModule } from '../material/material/material.module';
import { CoreModule } from '../core/core.module';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    SurgeryComponent,
    SurgeryItemComponent,
    SurgeryDetailsComponent
  ],
  imports: [
    CommonModule,
    SurgeryRoutingModule,
    MaterialModule,
    CoreModule,
    SharedModule
  ]
})
export class SurgeryModule { }
