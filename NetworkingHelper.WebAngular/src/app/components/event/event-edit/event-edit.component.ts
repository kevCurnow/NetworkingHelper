import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';
import { EventsService } from '../../../services/events.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Networking } from '../../../models/Networking';


@Component({
  selector: 'app-event-edit',
  templateUrl: './event-edit.component.html',
  styleUrls: ['./event-edit.component.css']
})
export class EventEditComponent implements OnInit {

  event: Networking;

  private editEventForm: FormGroup;
  constructor(private _form: FormBuilder,
              private _eventService: EventsService,
              private _ar: ActivatedRoute,
              private _router: Router) { 
    
    this._ar.paramMap.subscribe(p => {
      this._eventService.getEvent(p.get('id')).subscribe((singleEvent: Networking) => {
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
      EventLocation: new FormControl(this.event.EventLocation)
    });
  }

  onSubmit(form) {
    const updateNetworking: Networking = {
      EventID: form.value.EventID,
      EventName: form.value.EventName,
      EventDate: form.value.EventDate,
      EventLocation: form.value.EventLocation
    };
    this._eventService.updateNetworking(updateNetworking).subscribe(d => {
      this._router.navigate(['/events']);
    });
  }
}