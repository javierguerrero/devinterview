import { Component } from '@angular/core';

@Component({
  selector: 'app-layout-page',
  templateUrl: './layout-page.component.html',
  styles: [],
})
export class LayoutPageComponent {
  public sidebarItems = [
    { label: 'Subjects', icon: 'label', url: './list' },
    { label: 'Login', icon: 'login', url: '/auth/login' },
  ];
}
