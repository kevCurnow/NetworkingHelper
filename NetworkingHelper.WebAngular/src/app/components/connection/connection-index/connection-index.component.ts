import { Component, OnInit } from '@angular/core';
import { ConnectionsService } from '../../../services/connections.service';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { NetworkingC } from '../../../models/NetworkingC';

@Component({
  selector: 'app-connection-index',
  templateUrl: './connection-index.component.html',
  styleUrls: ['./connection-index.component.css']
})
export class ConnectionIndexComponent implements OnInit {

  connections: NetworkingC;
  columnNames = ['details', 'ConnectionID', 'ConnectionName', 'Job', "Employer", "Phone", "Email", "buttons"];
  dataSource: ConnectionDataSource | null;

  constructor(private _connectionService: ConnectionsService) { }

  ngOnInit() {
    this._connectionService.getConnections().subscribe((connections: NetworkingC[]) => {
      this.dataSource = new ConnectionDataSource(connections);
      // window.location.reload();
    });
  }

}

export class ConnectionDataSource extends DataSource<any> {

  constructor(private connectionsData: NetworkingC[]) {
    super();
  }

  connect(): Observable<NetworkingC[]> {
    return Observable.of(this.connectionsData);
  }

  disconnect() { }
}
