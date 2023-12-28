import { Component, Input, computed, signal } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';

export type MenuItem = {
  icon: string;
  label: string;
  route?: string;
}

@Component({
  selector: 'app-side-bars',
  templateUrl: './side-bars.component.html',
  styleUrls: ['./side-bars.component.scss']
})
export class SideBarsComponent {
  sideNavCollapsed = signal(false);
  @Input() set collapsed(val: boolean) {
    this.sideNavCollapsed.set(val);
  }

  constructor(public accountService: AccountService) { }


  menuItems = signal<MenuItem[]>([
    {
      icon: 'dashboard',
      label: 'Dashboard',
      route: 'dashboard',
    },
    {
      icon: 'personal_injury',
      label: 'Patient',
      route: 'patients',
    },
    {
      icon: 'calendar_month',
      label: 'Appointments',
      route: 'appointments',
    },
    {
      icon: 'content_cut',
      label: 'Surgeries',
      route: 'surgeries',
    },
    {
      icon: 'description',
      label: 'Notes',
      route: 'notes',
    },
  ]);

  profilePicSize = computed(() => (this.sideNavCollapsed() ? '32' : '100'));

}
