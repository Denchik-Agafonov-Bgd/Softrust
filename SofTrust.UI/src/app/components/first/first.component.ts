import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Message } from 'src/app/models/message';
import { Person } from 'src/app/models/person';
import { Subject } from 'src/app/models/subject';
import { PersonServices } from 'src/app/services/person.service';
import { SubjectService } from 'src/app/services/subject.service';
import { MessageService } from 'src/app/services/message.service';

@Component({
  selector: 'app-first',
  templateUrl: './first.component.html',
  styleUrls: ['./first.component.css']
})
export class FirstComponent {
  @Input() messageForm: Message = new Message;
  @Input() personForm: Person = new Person;


  form: FormGroup = new FormGroup({
    email: new FormControl('', [
      Validators.email,
      Validators.required
    ]),
    name: new FormControl(null, [
      Validators.required,
      Validators.minLength(2)
    ]),
    phone: new FormControl('', [
      Validators.required
    ]),
    message: new FormControl('', [
      Validators.required
    ]),
    subjectId: new FormControl('', [
      Validators.required
    ]),
    recaptcha: new FormControl('', [
      Validators.required
    ]),

  });
  title = 'SofTrust.UI';

  subjects: Subject[] = []
  message: Message = new Message
  person: Person = new Person

  siteKey = '6Ldkq-MkAAAAAG16wm76dnES4mCo-VQRe-eebM1Z'
  isCaptcha: boolean = true;

  constructor(
    private subjectServices: SubjectService,
    private messageService: MessageService,
    private formBuilder: FormBuilder,
    private personServices : PersonServices,
    private router: Router,
    ) {}

  ngOnInit(): void {
    this.subjectServices
    .getSubjects()
    .subscribe((result: Subject[]) => (this.subjects = result));
  }

  createMessage(){
    this.personServices
    .createPersonAndMessage(this.personForm, this.messageForm.subjectId, this.messageForm.message)
    .subscribe({
      next:(result: Person) => {this.person = result}
    });

    this.goToNextPage();
  }

  async goToNextPage() {
    await this.router.navigate(['/second']);
  }
}
