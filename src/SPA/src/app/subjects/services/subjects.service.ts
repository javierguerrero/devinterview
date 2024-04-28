import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';
import { Subject } from '../interfaces/subject.interface';
import { environments } from 'src/environments/environments';
import { Topic } from '../interfaces/topic.interface';

@Injectable({ providedIn: 'root' })
export class SubjectService {
  private baseUrl: string = environments.baseUrl;

  constructor(private http: HttpClient) {}

  getSubjects(): Observable<Subject[]> {
    var results = this.http.get<Subject[]>(`${this.baseUrl}/api/subjects`);
    return results;
  }

  getSubjectById(id: number): Observable<Subject | undefined> {
    return this.http
      .get<Subject>(`${this.baseUrl}/api/subjects/${id}`)
      .pipe(catchError((error) => of(undefined)));
  }

  getTopicsBySubject(subjectId: number): Observable<Topic[]> {
    var results = this.http.get<Topic[]>(
      `${this.baseUrl}/api/subjects/${subjectId}/topics`
    );
    return results;
  }
}
