import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { environment } from "src/environments/environment";
import { DataOutput } from "../models/dataOutput";

@Injectable({
  providedIn: 'root'
})
export class DataOutputService {
  private url = 'SofTrust/Output';
  constructor(private http: HttpClient) { }

  public getDataOutput(): Observable<DataOutput> {
    return this.http.get<DataOutput>(`${environment.apiUrl}/${this.url}`);
  }
}
