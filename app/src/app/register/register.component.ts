import { IUser } from './../models/iuser';
import { UserService } from './../services/user.service';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { CustomvalidationService } from '../services/customvalidation.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  @Output() formChange = new EventEmitter<boolean>();
  registerForm: FormGroup;
  submitted = false;
  newUser: IUser;

  constructor(
    private fb: FormBuilder,
    private customValidator: CustomvalidationService,
    private registerUserService: UserService
    ) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
        emailAddress: ['', [
          Validators.required,
          Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$')]],
        userName: ['', [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(30),
          Validators.pattern('^[a-zA-Z0-9]+([_-]?[a-zA-Z0-9])*$')]],
        password: ['', [
          Validators.required,
          /* Validators.minLength(8),
          Validators.maxLength(50),
        Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$')*/]],
        passwordRpt: ['', [
          Validators.required,
          /* Validators.minLength(8),
          Validators.maxLength(50),
          Validators.pattern('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])[a-zA-Z0-9]+$')*/]]
    },
    {
      validator: this.customValidator.MatchPassword('password', 'passwordRpt'),
    });
  }

  get registerFormControl() {
    return this.registerForm.controls;
  }

  onSubmit(form: FormGroup): void {
    if (this.registerForm.valid) {
      this.submitted = true;
      this.submitForm(form);
    } else {
      console.log('invalid');
    }
  }

  submitForm(form: FormGroup): void {
    console.log(form.value.emailAddress);
    this.newUser = {
      id : 0,
      rank: '',
      type: '',
      emailAddress : form.value.emailAddress,
      password : form.value.password,
      username : form.value.userName,
    };
    this.registerUserService
    .RegisterUser(this.newUser)
    .subscribe(response => {
      console.log(response);
      console.log('poszło');
    });
  }

  changeForm(): void{
    this.formChange.emit(true);
  }
}
