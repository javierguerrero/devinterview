import { Component, Input, OnInit } from '@angular/core';
import { Subject } from '../../interfaces/subject.interface';

@Component({
  selector: 'subject-card',
  templateUrl: './card.component.html',
  styles: [],
})
export class CardComponent implements OnInit {
  @Input()
  public subject!: Subject;

  ngOnInit(): void {
    if (!this.subject) {
      throw Error('Subject property is required');
    }
  }
}
