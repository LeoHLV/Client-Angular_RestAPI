import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { environment } from './../../environments/environment';
import { Client } from './../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  private url = 'Client';

  constructor(private http: HttpClient) { }

  public getClients(): Observable<Client[]> {
    return this.http.get<Client[]>(
      `${environment.apiUrl}/${this.url}`);
  }

  public createClient(client: Client): Observable<Client[]> {
    return this.http.post<Client[]>(
      `${environment.apiUrl}/${this.url}`, client);
  }

  public updateClient(client: Client): Observable<Client[]> {
    return this.http.put<Client[]>(
      `${environment.apiUrl}/${this.url}`, client);
  }

  public deleteClient(client: Client): Observable<Client[]> {
    return this.http.delete<Client[]>(
      `${environment.apiUrl}/${this.url}/${client.id}`);
  }

}
