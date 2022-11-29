import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class HttpService {
  baseUrl: string;

  constructor(private http: HttpClient) {
    this.baseUrl = environment.url;
  }

  post(url: string, data: object = {}, loading: boolean = true) {
    let myheader = new HttpHeaders().set(
      'isShowPageLoader',
      loading ? 'true' : 'false'
    );
    return this.http
      .post<any>(`${this.baseUrl}/${url}`, data, { headers: myheader })
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
  get(url: string, loading: boolean = false) {
    let myheader = new HttpHeaders().set(
      'isShowPageLoader',
      loading ? 'true' : 'false'
    );
    return this.http
      .get<any>(`${this.baseUrl}/${url}`, { headers: myheader })
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
}
