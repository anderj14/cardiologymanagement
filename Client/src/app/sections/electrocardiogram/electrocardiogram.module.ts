import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ElectrocardiogramComponent } from './electrocardiogram.component';
import { ElectrocardiogramDetailsComponent } from './electrocardiogram-details/electrocardiogram-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { ElectrocardiogramRoutingModule } from './electrocardiogram-routing.module';
import { MaterialModule } from 'src/app/material/material/material.module';



@NgModule({
  declarations: [
    ElectrocardiogramComponent,
    ElectrocardiogramDetailsComponent
  ],
  imports: [
    CommonModule,
    ElectrocardiogramRoutingModule,
    CoreModule,
    MaterialModule
  ]
})
export class ElectrocardiogramModule { }
