import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { apiUrl } from '../../global';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @Output() formChange = new EventEmitter<boolean>();
  loginForm: FormGroup;
  submitted = false;
  invalidLogin = false;
  isBusy = false;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      emailAddress: ['', [
        Validators.required,
        Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
      password: ['', [
        Validators.required,
        // Validators.minLength(8), <-- turned off, for testing purposes :)
        Validators.maxLength(50)]]
    });
  }

  onSubmit(form: FormGroup): void {
    this.isBusy = true;
    this.submitted = true;
    if (form) {
      console.table(form);
      this.submitForm(form);
    }
  }

  submitForm(form: FormGroup): void {
    const credentials = JSON.stringify(form.value);
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
      this.isBusy = false;
    }, err => {
      this.invalidLogin = true;
      console.log(err);
      console.log(credentials);
      this.isBusy = false;
    });
  }

  get loginFormControl() {
    return this.loginForm.controls;
  }

  changeForm(): void {
    this.formChange.emit(false);
  }
}
