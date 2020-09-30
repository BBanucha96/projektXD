import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  invalidLogin: boolean = false;
  private url = "https://localhost:44336/";

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }

  onSubmit(form: NgForm) {
    const credentials = JSON.stringify(form.value);
    this.http.post("https://localhost:44336/Auth/login", credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      const token = (<any>response).token;
      const uType = (<any>response).uType;
      localStorage.setItem("jwt", token);
      localStorage.setItem("uType", uType);
      this.invalidLogin = false;
      //this.router.navigate(["/"]);
      console.log("logged successfully!")
    }, err => {
      this.invalidLogin = true;
    });
  }

}
