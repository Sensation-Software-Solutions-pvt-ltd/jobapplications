import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from './http.servic';
@Injectable({
  providedIn: 'root'
})
export class ApiserviceService {
  constructor(private http: HttpService) { }
  ApplyForJob(filter: any = {}): Observable<any> {
    return this.http.post(
      'ApplyForJob', filter
    );
  }
}
