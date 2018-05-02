import { Component, OnInit } from '@angular/core';
import { ConnectionsService } from '../../../services/connections.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NetworkingC } from '../../../models/NetworkingC';

@Component({
  selector: 'app-connection-delete',
  templateUrl: './connection-delete.component.html',
  styleUrls: ['./connection-delete.component.css']
})
export class ConnectionDeleteComponent implements OnInit {
  public connection: NetworkingC;

  constructor(private _connectionService: ConnectionsService, private _ar: ActivatedRoute, private _router: Router) {
    this._ar.paramMap.subscribe(c => {
      this._connectionService.getConnection(c.get('id')).subscribe((singleConnection: NetworkingC) => {
        this.connection = singleConnection;
      });
    });
   }

  ngOnInit() {
  }

  onDelete() {
    this._connectionService.deleteConnection(this.connection.ConnectionID).subscribe(() => {
      this._router.navigate(['/connections'])
    });
  }
}
