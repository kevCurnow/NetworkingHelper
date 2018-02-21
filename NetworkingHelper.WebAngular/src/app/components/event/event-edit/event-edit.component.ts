import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { EventsService } from '../../../services/events.service';
import { ActivatedRoute, Router } from '@angular/router';
import { NetworkingE } from '../../../models/NetworkingE';


@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.css']
})
export class EventEditComponent implements OnInit {

  event: NetworkingE;

  private editEventForm: FormGroup;
  constructor(private _form: FormBuilder,
              private _eventService: EventsService,
              private _ar: ActivatedRoute,
              private _router: Router) { 
    
    this._ar.paramMap.subscribe(p => {
      this._eventService.getEvent(p.get('id')).subscribe((singleEvent: NetworkingE) => {
        this.event = singleEvent;
        this.createForm();
      });
    });
  }

  ngOnInit() {
  }

  createForm() {
    this.editEventForm = this._form.group({
      EventID: new FormControl(this.event.EventID),
      EventName: new FormControl(this.event.EventName),
      EventDate: new FormControl(this.event.EventDate),
      EventTime: new FormControl(this.event.EventTime),
      EventLocation: new FormControl(this.event.EventLocation)
    });
  }

  onSubmit(form) {
    const updateNetworking: NetworkingE = {
      EventID: form.value.EventID,
      EventName: form.value.EventName,
      EventDate: form.value.EventDate,
      EventTime: form.value.EventTime,
      EventLocation: form.value.EventLocation
    };
    this._eventService.updateNetworking(updateNetworking).subscribe(d => {
      this._router.navigate(['/events']);
    });
  }
}