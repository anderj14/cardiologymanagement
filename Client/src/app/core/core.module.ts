import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SideBarsComponent } from './side-bars/side-bars.component';
import { RouterModule } from '@angular/router';
import { NavBarDocheaderComponent } from './nav-bar-docheader/nav-bar-docheader.component';


@NgModule({
  declarations: [
    NavBarComponent,
    SideBarsComponent,
    NavBarDocheaderComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    NavBarComponent,
    SideBarsComponent,
    NavBarDocheaderComponent
  ]
})
export class CoreModule { }
