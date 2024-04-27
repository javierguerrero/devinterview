import { Component } from '@angular/core';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styles: [],
})
export class NewPageComponent {
  public stages = [
    { id: 1, name: 'Applied' },
    { id: 2, name: 'Interview' },
    { id: 3, name: 'Offer' },
    { id: 4, name: 'Rejected' },
  ];
}
