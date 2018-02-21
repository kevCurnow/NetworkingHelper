import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { ConnectionsService } from '../../../services/connections.service';
import { EventsService } from '../../../services/events.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NetworkingE } from '../../../models/NetworkingE';
import { NetworkingC } from '../../../models/NetworkingC';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Component({
  selector: 'app-connection-edit',
  templateUrl: './connection-edit.component.html',
  styleUrls: ['./connection-edit.component.css']
})
export class ConnectionEditComponent implements OnInit {
  connection: NetworkingC;
  selectedEvent: NetworkingE;
  events: NetworkingE[];
  dataSource: EventsDataSource | null;

  private editConnectionForm: FormGroup
  constructor(private _form: FormBuilder,
    private _connectionService: ConnectionsService,
    private _eventService: EventsService,
    private _ar: ActivatedRoute,
    private _router: Router) {

    this._ar.paramMap.subscribe(p => {
      this._connectionService.getConnection(p.get('id')).subscribe((singleConnection: NetworkingC) => {
        this.connection = singleConnection;
        this.createForm();
      });
    });
  }

  ngOnInit() {
    this._eventService.getEvents().subscribe((events: NetworkingE[]) => {
      this.events = events;
      this.dataSource = new EventsDataSource(events);
    });
  }

  createForm() {
    this.editConnectionForm = this._form.group({
      ConnectionName: new FormControl(this.connection.ConnectionName),
      Job: new FormControl(this.connection.Job),
      Employer: new FormControl(this.connection.Employer),
      Phone: new FormControl(this.connection.Phone),
      Email: new FormControl(this.connection.Email),
      Notes: new FormControl(this.connection.Notes),
      EventID: new FormControl(this.connection.EventID)
    });
  }

  onSubmit(form) {
    const updateNetworking: NetworkingC = {
      ConnectionName: form.value.ConnectionName,
      Job: form.value.Job,
      Employer: form.value.Employer,
      Phone: form.value.Phone,
      Email: form.value.Email,
      Notes: form.value.Notes,
      EventID: form.value.EventID
    };
    this._connectionService.updateNetworking(updateNetworking).subscribe(d => {
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

  disconnect() { }
}
