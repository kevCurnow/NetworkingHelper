import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { 
  MatToolbarModule, 
  MatButtonModule,
  MatFormFieldModule,
  MatInputModule,
  MatTableModule
} from '@angular/material';


import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { AuthService } from './services/auth.service';
import { LoginComponent } from './components/login/login.component';
import { EventsService } from './services/events.service';
import { EventIndexComponent } from './components/event/event-index/event-index.component';
import { EventCreateComponent } from './components/event/event-create/event-create.component';
import { EventDetailComponent } from './components/event-detail/event-detail.component';
import { EventEditComponent } from './components/event/event-edit/event-edit.component';
import { EventDeleteComponent } from './components/event/event-delete/event-delete.component';
import { AuthGuard } from './guards/auth.guards';

const routes = [
  { path: 'register', component: RegistrationComponent},
  { path: 'login', component: LoginComponent},
  { path: 'events', canActivate: [AuthGuard] , children: [
    { path: '', component: EventIndexComponent},
    { path: 'create', component: EventCreateComponent},
    { path: 'detail/:id', component: EventDetailComponent},
    { path: 'edit/:id', component: EventEditComponent},
    { path: 'delete/:id', component: EventDeleteComponent}
    ]
  },
  { path: '**', component: RegistrationComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    RegistrationComponent,
    LoginComponent,
    EventIndexComponent,
    EventCreateComponent,
    EventDetailComponent,
    EventEditComponent,
    EventDeleteComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    FormsModule,
    RouterModule.forRoot(routes),
    HttpClientModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatTableModule
  ],
  providers: [
    AuthService,
    EventsService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
