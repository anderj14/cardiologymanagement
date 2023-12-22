import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotesComponent } from './notes.component';
import { NotesItemComponent } from './notes-item/notes-item.component';
import { NotesDetailsComponent } from './notes-details/notes-details.component';



@NgModule({
  declarations: [
    NotesComponent,
    NotesItemComponent,
    NotesDetailsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class NotesModule { }
