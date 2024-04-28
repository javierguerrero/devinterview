import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../../services/subjects.service';
import { ActivatedRoute, Router } from '@angular/router';
import { delay, switchMap } from 'rxjs';
import { Subject } from '../../interfaces/subject.interface';
import { Topic } from '../../interfaces/topic.interface';

@Component({
  selector: 'app-subject-page',
  templateUrl: './subject-page.component.html',
  styles: [],
})
export class SubjectPageComponent implements OnInit {
  public topics: Topic[] = [];

  constructor(
    private subjectService: SubjectService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.activatedRoute.params
      .pipe(
        delay(1000),
        switchMap(({ id }) => this.subjectService.getTopicsBySubject(id))
      )
      .subscribe((topics) => {
        this.topics = topics;
        return;
      });
  }

  goBack(): void {
    this.router.navigateByUrl('subjects/list');
  }
}
