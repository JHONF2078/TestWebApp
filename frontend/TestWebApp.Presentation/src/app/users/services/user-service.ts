import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, Subject, of, tap } from 'rxjs';
import { User } from '../interface/user';
import { environment } from '../../../environments/environment';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiUrl = `${environment.apiUrl}/user`;

  constructor(private http: HttpClient) {
    this.getAllUsers();
  }

  private userSubject = new BehaviorSubject<User[]>([]);

  listUser$ = this.userSubject.asObservable();

  getAllUsers(forceRefresh: boolean = false): Observable<User[]> {
    if (forceRefresh) {
      return this.http.get<User[]>(this.apiUrl).pipe(
        tap(users => this.userSubject.next(users)) // actualiza el cache
      );
    } else {
      return this.listUser$; // datos en memoria
    }
  }
}
