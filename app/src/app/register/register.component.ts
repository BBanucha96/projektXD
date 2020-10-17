import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  @Output() formChange = new EventEmitter<boolean>();

  constructor() { }

  registerForm: any;

  ngOnInit(): void {
  }

  onSubmit(): void{
  }

  changeForm(): void{
    this.formChange.emit(true);
  }

}
