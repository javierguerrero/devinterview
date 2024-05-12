import { Component } from '@angular/core';

@Component({
  selector: 'app-layout-page',
  templateUrl: './layout-page.component.html',
  styleUrls: ['layout-page.component.css'],
})
export class LayoutPageComponent {
  public sidebarItems = [
    { label: 'Home', icon: 'home', url: './list' },
    { label: 'Sign Up', icon: 'app_registration', url: '/auth/register' },
    { label: 'Login', icon: 'login', url: '/auth/login' },
  ];
}
