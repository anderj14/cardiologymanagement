import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { NotesComponent } from './notes.component';
import { NotesDetailsComponent } from './notes-details/notes-details.component';

const routes: Routes = [
  { path: '', component: NotesComponent },
  { path: ':id', component: NotesDetailsComponent },
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class NotesRoutingModule { }
