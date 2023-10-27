import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EchocardiogramComponent } from './echocardiogram.component';
import { EchocardiogramDetailsComponent } from './echocardiogram-details/echocardiogram-details.component';
import { CoreModule } from 'src/app/core/core.module';
import { RouterModule } from '@angular/router';
import { EchocardiogramRoutingModule } from './echocardiogram-routing.module';



@NgModule({
  declarations: [
    EchocardiogramComponent,
    EchocardiogramDetailsComponent
  ],
  imports: [
    CommonModule,
    CoreModule,
    EchocardiogramRoutingModule
  ]
})
export class EchocardiogramModule { }
