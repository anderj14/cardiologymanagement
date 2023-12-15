import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule} from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PaginationComponent } from './pagination/pagination.component';
import { MaterialModule } from '../material/material/material.module';


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PaginationComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    PaginationModule.forRoot()
  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PaginationComponent
  ]
})
export class SharedModule { }
