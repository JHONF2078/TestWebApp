import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class HelloService {
  private apiUrl = 'https://localhost:5001/api/hello';

  constructor(private http: HttpClient) { }

  getGreeting(): Observable<string> {
    return this.http.get(this.apiUrl, { responseType: 'text' });
  }
}
