import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonServices {
  private url = 'SofTrust/CreateMessage';
  constructor(private http: HttpClient) { }

  public createPersonAndMessage(person: Person, subjectId?: number, message?: string)  {
    return this.http.post<Person>(
    `${environment.apiUrl}/${this.url}?subjectId=${subjectId}&message=${message}`,
    person
    );
  }
}
