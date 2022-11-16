import { ClientService } from './../../services/client.service';
import { Client } from './../../models/client';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-edit-client',
  templateUrl: './edit-client.component.html',
  styleUrls: ['./edit-client.component.css']
})
export class EditClientComponent implements OnInit {
  @Input() client?: Client;
  @Output() clientsUpdated = new EventEmitter<Client[]>();

  constructor(private clientService: ClientService) { }

  ngOnInit(): void { }

  createClient(client: Client) {
    this.clientService
      .createClient(client)
      .subscribe((clients: Client[]) => this.clientsUpdated
        .emit(clients));
  }

  updateClient(client: Client) {
    this.clientService
      .updateClient(client)
      .subscribe((clients: Client[]) => this.clientsUpdated
        .emit(clients));
  }

  deleteClient(client: Client) {
    this.clientService
      .deleteClient(client)
      .subscribe((clients: Client[]) => this.clientsUpdated
        .emit(clients));
  }
}
