import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HttpClientModule } from '@angular/common/http';
import { HelloService } from '../services/hello.service';

@Component({
  standalone: true,
  selector: 'app-hello',
  imports: [CommonModule, HttpClientModule],
  template: `
    <h1>Conexión Angular + API</h1>
    <p *ngIf="mensaje">{{ mensaje }}</p>
  `
})
export class HelloComponent implements OnInit {
  mensaje = '';

  constructor(private helloService: HelloService) { }

  ngOnInit(): void {
    this.helloService.getGreeting().subscribe({
      next: msg => this.mensaje = msg,
      error: err => console.error('Error al conectar con la API', err)
    });
  }
}
