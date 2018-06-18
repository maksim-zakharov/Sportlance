import {Component, Input, OnInit} from '@angular/core';
import {Router} from '@angular/router';
import {Paths} from '../../core/paths';
import {UserService} from '../../services/user.service/user.service';
import {User} from '../../services/user.service/user';
import {AccountService} from '../../services/account-service';

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  @Input() public isEmpty: false;

  public currentUser: User;
  public isAuthorized = false;
  public Paths = Paths;

  constructor(private router: Router,
              private userService: UserService,
              private accountService: AccountService) {
    this.accountService.authStatusChanged.subscribe(async () => await this.updateUserAsync());
  }

  async ngOnInit() {
    return await this.updateUserAsync();
  }

  public async updateUserAsync(): Promise<void> {
    if (this.accountService.isAuthorized) {
      this.currentUser = await this.userService.getCurrent();
      this.isAuthorized = true;
    } else {
      this.currentUser = null;
      this.isAuthorized = false;
    }
  }

  login() {
    this.router.navigate([Paths.Login]);
  }

  async registerAsync() {
    await this.router.navigate([Paths.SignUp]);
  }

  navigateToAccount() {
    this.router.navigate([Paths.Account]);
  }

  logout() {
    this.accountService.logout();
    this.router.navigate([Paths.Login]);
  }
}
