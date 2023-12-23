import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotesComponent } from './notes.component';
import { NotesItemComponent } from './notes-item/notes-item.component';
import { NotesDetailsComponent } from './notes-details/notes-details.component';
import { NotesRoutingModule } from './notes-routing.module';
import { MaterialModule } from '../material/material/material.module';
import { SharedModule } from '../shared/shared.module';
import { CoreModule } from '../core/core.module';



@NgModule({
  declarations: [
    NotesComponent,
    NotesItemComponent,
    NotesDetailsComponent
  ],
  imports: [
    CommonModule,
    NotesRoutingModule,
    MaterialModule,
    SharedModule,
    CoreModule
  ]
})
export class NotesModule { }
