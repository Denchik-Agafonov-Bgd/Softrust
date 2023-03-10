import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from 'src/environments/environment';
import { Message } from '../models/message';
import { Person } from '../models/person';
import { Subject } from '../models/subject';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private url = 'SofTrust/CreateMessage';
  constructor(private http: HttpClient) { }

  public createMessage(message: Message) {
    return this.http.post<Message>(
    `${environment.apiUrl}/${this.url}`,
    message
    );
  }
}
