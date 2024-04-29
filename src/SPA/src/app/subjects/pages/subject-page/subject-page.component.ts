import { Component, OnInit } from '@angular/core';
import { SubjectService } from '../../services/subjects.service';
import { ActivatedRoute, Router } from '@angular/router';
import { delay, switchMap } from 'rxjs';
import { Topic } from '../../interfaces/topic.interface';
import { Question } from '../../interfaces/question.interface';

@Component({
  selector: 'app-subject-page',
  templateUrl: './subject-page.component.html',
  styleUrls: ['subject-page.component.css'],
})
export class SubjectPageComponent implements OnInit {
  public topics: Topic[] | null = null;
  public questions: Question[] | null = null;

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

  getQuestions(topicId: number) {
    this.subjectService
      .getQuestions(topicId)
      .subscribe((questions) => (this.questions = questions));
  }

  goBack(): void {
    this.router.navigateByUrl('subjects/list');
  }
}
