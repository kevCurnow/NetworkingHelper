import { Component, OnInit } from '@angular/core';
import { EventsService } from '../../../services/events.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NetworkingE } from '../../../models/NetworkingE';

@Component({
  selector: 'app-event-delete',
  templateUrl: './event-delete.component.html',
  styleUrls: ['./event-delete.component.css']
})
export class EventDeleteComponent implements OnInit {
  public event: NetworkingE;

  constructor(private _eventService: EventsService, private _ar: ActivatedRoute, private _router: Router) {
    this._ar.paramMap.subscribe(p => {
      this._eventService.getEvent(p.get('id')).subscribe((singleEvent: NetworkingE) => {
        this.event = singleEvent;
      });
    });
   }

  ngOnInit() {
  }

  onDelete() {
    this._eventService.deleteEvent(this.event.EventID).subscribe(() => {
      this._router.navigate(['/events'])
    });
  }
}
