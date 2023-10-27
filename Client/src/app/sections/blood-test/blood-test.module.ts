import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BloodTestComponent } from './blood-test.component';
import { BloodTestDetailsComponent } from './blood-test-details/blood-test-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { BloodTestRoutingModule } from './blood-test-routing.module';



@NgModule({
  declarations: [
    BloodTestComponent,
    BloodTestDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    BloodTestRoutingModule
  ]
})
export class BloodTestModule { }
