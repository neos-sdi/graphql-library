import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-book-form',
  templateUrl: './book-form.component.html',
  styleUrls: ['./book-form.component.scss']
})
export class BookFormComponent implements OnInit {
  formGroup = new FormGroup({
    id: new FormControl(),
    title: new FormControl(),
    description: new FormControl()
  })
  @Input() set book(value: any){
    if(value){
      this.formGroup.setValue({
        id: value.id,
        title: value.title,
        description: value.description
      })
    }
  }
  @Output() onClose = new EventEmitter()
  @Output() onSave = new EventEmitter<any>()
  constructor() { }

  ngOnInit(): void {
  }

  cancel(){
    this.onClose.emit();
    this.formGroup.reset({})
  }

  save(){
    this.onSave.emit(this.formGroup.value)
    this.formGroup.reset({})
  }

}
