import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { UserInfo } from '../../models/UserInfo';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  username: string;
  isLoggedIn:boolean;
  constructor(public authService: AuthService) { }

  ngOnInit() {
    this.authService.currentUser().subscribe((userInfo: UserInfo) => {
      if (userInfo) {
        this.isLoggedIn = true;
        this.username = userInfo.Email;
      } else {
        this.isLoggedIn = false;
      }
    }
  );
  this.authService.isLoggedIn.subscribe(v => this.isLoggedIn = v);
  }
  onLogoutClicked() {
    this.authService.logout();
    window.location.reload();
  }
}
