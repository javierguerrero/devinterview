import { Component, OnInit } from '@angular/core';
import { Subject } from '../../interfaces/subject.interface';
import { SubjectService } from '../../services/subjects.service';

@Component({
  selector: 'app-list-page',
  templateUrl: './list-page.component.html',
  styles: [],
})
export class ListPageComponent implements OnInit {
  public subjects: Subject[] = [];

  constructor(private subjectService: SubjectService) {}

  ngOnInit(): void {
    this.subjectService
      .getSubjects()
      .subscribe((subjects) => (this.subjects = subjects));
  }
}
