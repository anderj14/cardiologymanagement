import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StressTestComponent } from './stress-test.component';
import { StressTestDetailsComponent } from './stress-test-details/stress-test-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { StressTestRoutingModule } from './stress-test-routing.module';


@NgModule({
  declarations: [
    StressTestComponent,
    StressTestDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    StressTestRoutingModule
  ]
})
export class StressTestModule { }
