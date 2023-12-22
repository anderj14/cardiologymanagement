import { Component, Input } from '@angular/core';
import { Surgery } from 'src/app/shared/Models/surgery';

@Component({
  selector: 'app-surgery-item',
  templateUrl: './surgery-item.component.html',
  styleUrls: ['./surgery-item.component.scss']
})
export class SurgeryItemComponent {
  @Input() surgery?: Surgery;
}
