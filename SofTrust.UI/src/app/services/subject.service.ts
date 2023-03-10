import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from '../../environments/environment';
import { Subject } from '../models/subject';

@Injectable({
  providedIn: 'root'
})
export class SubjectService {
  private url = 'SofTrust';
  constructor(private http: HttpClient) { }

  public getSubjects(): Observable<Subject[]> {
    return this.http.get<Subject[]>(`${environment.apiUrl}/${this.url}`);
  }
}
