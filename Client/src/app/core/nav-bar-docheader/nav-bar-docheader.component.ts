import { Component, computed, signal } from '@angular/core';
import { AccountService } from 'src/app/account/account.service';

@Component({
  selector: 'app-nav-bar-docheader',
  templateUrl: './nav-bar-docheader.component.html',
  styleUrls: ['./nav-bar-docheader.component.scss']
})
export class NavBarDocheaderComponent {
  collapsed = signal(false);

  sidenavWidth = computed(() => this.collapsed() ? '65px' : '250px');

  constructor(public accountService: AccountService) {}

  

}
