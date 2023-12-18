import { Component, Input } from '@angular/core';
import { Appointment } from 'src/app/shared/Models/appointment';

@Component({
  selector: 'app-appointment-item',
  templateUrl: './appointment-item.component.html',
  styleUrls: ['./appointment-item.component.scss']
})
export class AppointmentItemComponent {

  @Input() appointmet?: Appointment;

  getStatusClass(status: string): string {
    const lowercaseStatus = status.toLowerCase();

    switch (lowercaseStatus) {
      case 'pending':
        return 'pending';
      case 'canceled':
        return 'canceled';
      case 'realiced':
        return 'realiced';
      default:
        return '';
    }
  }

}
