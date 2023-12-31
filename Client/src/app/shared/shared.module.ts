import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagingHeaderComponent } from './paging-header/paging-header.component';
import { PaginationComponent } from './pagination/pagination.component';
import { MaterialModule } from '../material/material/material.module';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TextInputComponent } from './components/text-input/text-input.component';


@NgModule({
  declarations: [
    PagingHeaderComponent,
    PaginationComponent,
    TextInputComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    PaginationModule.forRoot(),
    ReactiveFormsModule,
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
  ],
  exports: [
    PaginationModule,
    PagingHeaderComponent,
    PaginationComponent,
    ReactiveFormsModule,
    BsDropdownModule,
    TextInputComponent,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class SharedModule { }
