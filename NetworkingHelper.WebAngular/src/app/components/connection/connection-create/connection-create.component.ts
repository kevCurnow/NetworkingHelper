import { Component, OnInit } from '@angular/core';
import { ConnectionsService } from '../../../services/connections.service';
import { NetworkingE } from '../../../models/NetworkingE';
import { NetworkingC } from '../../../models/NetworkingC';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { EventsService } from '../../../services/events.service';
import { DataSource } from '@angular/cdk/collections';

@Component({
  selector: 'app-connection-create',
  templateUrl: './connection-create.component.html',
  styleUrls: ['./connection-create.component.css'],
  providers: [EventsService,
    ConnectionsService]
})
export class ConnectionCreateComponent implements OnInit {
  selectedEvent: NetworkingE;
  connectionForm: FormGroup;
  events: NetworkingE[];
  dataSource: EventsDataSource | null;

  constructor(private _eventService: EventsService, private _connectionService: ConnectionsService, private _form: FormBuilder, private _router: Router) {
    this.createForm();
  }

  ngOnInit() {
    this._eventService.getEvents().subscribe((events: NetworkingE[]) => {
      this.events = [];
      Object.keys(events).forEach((eachEvent) => {
        this.events.push(events[eachEvent])
      })
      this.dataSource = new EventsDataSource(events);
    });
  }

  createForm() {
    this.connectionForm = this._form.group({
      ConnectionName: new FormControl,
      Job: new FormControl,
      Employer: new FormControl,
      Phone: new FormControl,
      Email: new FormControl,
      Notes: new FormControl,
      EventID: new FormControl
    });
  }

  onSubmit() {
    this._connectionService.createConnections(this.connectionForm.value).subscribe(data => {
      this._router.navigate(['/connections']);
    });
  }
}

export class EventsDataSource extends DataSource<any> {

  constructor(private eventsData: NetworkingE[]) {
    super();
  }

  connect(): Observable<NetworkingE[]> {
    return Observable.of(this.eventsData);
  }

  disconnect() {}
}
