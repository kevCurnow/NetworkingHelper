import { Component, OnInit } from '@angular/core';
import { EventsService } from '../../../services/events.service';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';
import { NetworkingE } from '../../../models/NetworkingE';

@Component({
  selector: 'app-event-index',
  templateUrl: './event-index.component.html',
  styleUrls: ['./event-index.component.css']
})
export class EventIndexComponent implements OnInit {

  events: NetworkingE[];
  columnNames = ['details', 'EventID', 'EventName', 'EventDate', 'EventTime', 'EventLocation', 'buttons'];
  dataSource: EventDataSource | null;

  constructor(private _eventService: EventsService) { }

  ngOnInit() {
    this._eventService.getEvents().subscribe((events: NetworkingE[]) => {
      this.events = events;
      this.dataSource = new EventDataSource(events);
      // window.location.reload();
    });
  }

}

export class EventDataSource extends DataSource<any> {

  constructor(private eventsData: NetworkingE[]) {
    super();
  }

  connect(): Observable<NetworkingE[]> {
    return Observable.of(this.eventsData);
  }

  disconnect() { }
}
