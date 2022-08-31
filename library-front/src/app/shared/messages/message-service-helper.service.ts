import { Injectable } from '@angular/core';
import { Message, MessageService } from 'primeng/api';
import { SimpleMessage } from './simple-message';

@Injectable({
  providedIn: 'root'
})
export class MessageServiceHelper {

  constructor(private messageService: MessageService) {}

  add(message: Message) {
    this.messageService.add(message);
  }

  addAll(messages: Message[]) {
    this.messageService.addAll(messages);
  }

  clear(key: string | undefined) {
    this.messageService.clear(key);
  }

  addError(message: SimpleMessage) {
    this.add({
      ...message,
      summary: 'Erreur',
      severity: 'error',
      icon: 'bi-x-octagon-fill',
    });
  }

  addWarning(message: SimpleMessage) {
    this.add({
      ...message,
      severity: 'warning',
      summary: 'Attention !',
      icon: 'bi-exclamation-triangle-fill',
    });
  }

  addSuccess(message: SimpleMessage) {
    console.log('success');
    this.add({
      ...message,
      summary: 'Bravo !',
      severity: 'success',
      icon: 'bi-check-square-fill',
    });
  }

  addInfo(message: SimpleMessage) {
    this.add({
      ...message,
      summary: 'Pour information',
      severity: 'info',
      icon: 'bi-info-circle-fill',
    });
  }
}
