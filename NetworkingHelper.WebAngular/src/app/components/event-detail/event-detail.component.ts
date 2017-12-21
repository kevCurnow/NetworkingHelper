import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Networking } from '../../models/Networking';
import { EventsService } from '../../services/events.service';

@Component({
  selector: 'app-event-detail',
  templateUrl: './event-detail.component.html',
  styleUrls: ['./event-detail.component.css']
})
export class EventDetailComponent implements OnInit {

  event: Event;

  constructor(private _activatedRoute: ActivatedRoute, private _eventService: EventsService) { }

  ngOnInit() {
    this._activatedRoute.paramMap.subscribe(routeData => {
      this._eventService.getEvent(routeData.get('id')).subscribe((singleEvent: Event) => {
        this.event = singleEvent;
      });
    });
  }
}
