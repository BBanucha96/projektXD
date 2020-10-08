import { AppComponent } from './../app.component';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';
import { apiUrl } from '../../global';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  invalidLogin = false;

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm): void {
    const credentials = JSON.stringify(form.value);
    console.log(credentials);
    this.http.post(`${apiUrl}Auth/login`, credentials, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    }).subscribe(response => {
      const token = (response as any).token;
      const uType = (response as any).uType;
      localStorage.setItem('jwt', token);
      localStorage.setItem('uType', uType);
      this.invalidLogin = false;
      this.router.navigate(['/']);
      console.log('logged successfully!');
    }, err => {
      this.invalidLogin = true;
    });
  }
}
