import { Component, Input } from '@angular/core';
import { Note } from 'src/app/shared/Models/note';

@Component({
  selector: 'app-notes-item',
  templateUrl: './notes-item.component.html',
  styleUrls: ['./notes-item.component.scss']
})
export class NotesItemComponent {

  @Input() note?: Note;

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
