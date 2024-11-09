import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class DarkAngelsService {

  private apiUrl = 'http://localhost:5086/api/darkangels'

  constructor(private http: HttpClient) { }

  getUnits(): Observable<any> {
    return this.http.get(this.apiUrl);
  }
}
