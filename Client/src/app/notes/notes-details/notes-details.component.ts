import { Component, OnInit } from '@angular/core';
import { Note } from 'src/app/shared/Models/note';
import { NotesService } from '../notes.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-notes-details',
  templateUrl: './notes-details.component.html',
  styleUrls: ['./notes-details.component.scss']
})
export class NotesDetailsComponent implements OnInit {

  note!: Note;

  constructor(
    private noteService: NotesService,
    private activateRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.loadNote();
  }

  loadNote() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    if (id) {
      this.noteService.getNote(+id).subscribe({
        next: note => this.note = note,
        error: error => console.log(error)
      });
    }
  }

  getStatusClass(status: string): string {
    const lowercaseStatus = status.toLowerCase();

    switch (lowercaseStatus) {
      case 'pending':
        return 'pending';
      case 'in progress':
        return 'in-progress';
      case 'completed':
        return 'completed';
      default:
        return '';
    }
  }
}
