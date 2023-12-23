import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Note } from '../shared/Models/note';
import { NoteParams } from '../shared/Models/noteParams';
import { NotesService } from './notes.service';
import { AppointmentStatus } from '../shared/Models/appointmentStatus';
import { NoteStatus } from '../shared/Models/noteStatus';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.scss']
})
export class NotesComponent implements OnInit {
  @ViewChild('search') searchTerm?: ElementRef;

  notes!: Note[];
  noteStatuses!: NoteStatus[];
  
  noteParams = new NoteParams();
  
  sortOptions = [
    { name: 'Alphabetical', value: 'name' },
    { name: 'Date Ascending', value: 'dateAsc' },
    { name: 'Date Descending', value: 'dateDesc' }
  ]

  totalCount = 0;

  constructor(private noteService: NotesService) { }

  ngOnInit(): void {
    this.getNotes();
    this.getNoteStatus();
  }

  getNotes() {
    this.noteService.getNotes(this.noteParams).subscribe({
      next: response => {
        this.notes = response.data;
        this.noteParams.pageNumber = response.pageIndex;
        this.noteParams.pageSize = response.pageSize;
        this.totalCount = response.count;
      },
      error: error => console.log(error)
    });
  }


  onSortSelected(event: any) {
    this.noteParams.sort = event.target.value;
    this.getNotes();
  }

  onPageChanged(event: any) {
    if (this.noteParams.pageNumber !== event.page) {
      this.noteParams.pageNumber = event.page;
      this.getNotes();
    }
  }

  onSearch() {
    this.noteParams.search = this.searchTerm?.nativeElement.value;
    this.noteParams.pageNumber = 1;
    this.getNotes();
  }

  onReset() {
    if (this.searchTerm) this.searchTerm.nativeElement.value = '';
    this.noteParams = new NoteParams();
    this.getNotes();
  }

  getNoteStatus() {
    this.noteService.getNoteStatus().subscribe({
      next: response => this.noteStatuses = [{ id: 0, noteStatusName: 'All' }, ...response],
      error: error => console.log(error)
    });
  }

  onNoteStatusSelected(noteStatusId: number) {
    this.noteParams.noteStatusId = noteStatusId;
    this.noteParams.pageNumber = 1;
    this.getNotes();
  }

  showPopup = false;

  togglePopup() {
    this.showPopup = !this.showPopup;
  }

  closePopup() {
    this.showPopup = false;
  }
  stopPropagation(event: Event) {
    event.stopPropagation();
  }
}
