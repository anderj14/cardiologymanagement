import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SideBarsComponent } from './side-bars/side-bars.component';
import { RouterModule } from '@angular/router';
import { NavBarDocheaderComponent } from './nav-bar-docheader/nav-bar-docheader.component';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastrModule } from 'ngx-toastr';
import { MaterialModule } from '../material/material/material.module';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    NavBarComponent,
    SideBarsComponent,
    NavBarDocheaderComponent,
    TestErrorComponent,
    NotFoundComponent,
    ServerErrorComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    MaterialModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true
    }),
    SharedModule
  ],
  exports: [
    NavBarComponent,
    SideBarsComponent,
    NavBarDocheaderComponent
  ]
})
export class CoreModule { }
