import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NetworkingC } from '../../../models/NetworkingC';
import { ConnectionsService } from '../../../services/connections.service';

@Component({
  selector: 'app-connection-detail',
  templateUrl: './connection-detail.component.html',
  styleUrls: ['./connection-detail.component.css']
})
export class ConnectionDetailComponent implements OnInit {

  connection: NetworkingC;

  constructor(private _activatedRoute: ActivatedRoute, private _connectionService: ConnectionsService) { }

  ngOnInit() {
    this._activatedRoute.paramMap.subscribe(routeData => {
      this._connectionService.getConnection(routeData.get('id')).subscribe((singleConnection: NetworkingC) => {
        this.connection = singleConnection;
      });
    });
  }
}
