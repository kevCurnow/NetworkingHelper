import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { NetworkingC } from '../models/NetworkingC'

const Api_Url = 'http://localhost:55996/';

@Injectable()
export class ConnectionsService {

  constructor(private _http: HttpClient) { }

  getConnections() {
    return this._http.get(`${Api_Url}/api/Connection` , { headers: this.getHeaders()});
  }

  createConnections(connection: NetworkingC) {
    return this._http.post(`${Api_Url}/api/Connection`, connection, {headers: this.getHeaders()});
  }

  getConnection(id: string){
    return this._http.get(`${Api_Url}/api/Connection/${id}`, { headers: this.getHeaders() });
  }

  updateNetworking(connection: NetworkingC){
    return this._http.put(`${Api_Url}/api/Connection`, connection, { headers: this.getHeaders()});
  }

  deleteConnection(id: number) {
    return this._http.delete(`${Api_Url}/api/Connection/${id}`, { headers: this.getHeaders() });
  }
  private getHeaders(){
    return new HttpHeaders().set('Authorization', `Bearer ${localStorage.getItem('id_token')}`);
  }

}