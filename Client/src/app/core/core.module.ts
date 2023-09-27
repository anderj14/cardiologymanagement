import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SideBarsComponent } from './side-bars/side-bars.component';


@NgModule({
  declarations: [
    NavBarComponent,
    SideBarsComponent,


  ],
  imports: [
    CommonModule,
  ],
  exports: [
    NavBarComponent,
    SideBarsComponent,
  ]
})
export class CoreModule { }
