import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IUser } from '../models/iuser';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private url = "https://localhost:44336/";
  constructor(private http: HttpClient) { }

  public RegisterUser(user: IUser): Observable<boolean> {
    return this.http.post<boolean>(this.url + 'Users', user);
  }
}
