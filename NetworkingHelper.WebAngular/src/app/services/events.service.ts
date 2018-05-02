import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NetworkingE } from '../models/NetworkingE'

const Api_Url = 'http://localhost:55996/';

@Injectable()
export class EventsService {

  constructor(private _http: HttpClient) { }

  getEvents() {
    return this._http.get(`${Api_Url}/api/Event`, {headers: this.getHeaders()});
  }

  createEvents(event: NetworkingE) {
    return this._http.post(`${Api_Url}/api/Event`, event, {headers: this.getHeaders()});
  }

  getEvent(id: string){
    return this._http.get(`${Api_Url}/api/Event/${id}`, {headers: this.getHeaders()});
  }

  updateNetworking(event: NetworkingE){
    return this._http.put(`${Api_Url}/api/Event`, event, {headers: this.getHeaders()});
  }

  deleteEvent(id: number) {
    return this._http.delete(`${Api_Url}/api/Event/${id}`, {headers: this.getHeaders()});
  }
  private getHeaders(){
    return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('id_token')}`);
  }

}
