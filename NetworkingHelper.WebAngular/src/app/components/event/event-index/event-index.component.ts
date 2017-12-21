import { Component, OnInit } from '@angular/core';
import { EventsService } from '../../../services/events.service';
import { Networking } from '../../../models/Networking';
import { DataSource } from '@angular/cdk/collections';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/of';

@Component({
  selector: 'app-event-index',
  templateUrl: './event-index.component.html',
  styleUrls: ['./event-index.component.css']
})
export class EventIndexComponent implements OnInit {

  events: Event[];
  columnNames = ['details', 'EventID', 'EventName', 'EventDate', 'EventLocation', 'buttons'];
  dataSource: EventDataSource | null;

  constructor(private _eventService: EventsService) { }

  ngOnInit() {
    this._eventService.getEvents().subscribe((events: Event[]) => {
      this.dataSource = new EventDataSource(events);
    });
  }

}

export class EventDataSource extends DataSource<any> {

  constructor(private eventsData: Event[]) {
    super();
  }

  connect(): Observable<Event[]> {
    return Observable.of(this.eventsData);
  }

  disconnect() { }
}
