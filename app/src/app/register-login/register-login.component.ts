import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-register-login',
  templateUrl: './register-login.component.html',
  styleUrls: ['./register-login.component.scss']
})
export class RegisterLoginComponent implements OnInit {

  constructor() { }

  isLoginForm = true;

  ngOnInit(): void {
  }

  changeForm(data: any): void{
    this.isLoginForm = data;
  }

}
