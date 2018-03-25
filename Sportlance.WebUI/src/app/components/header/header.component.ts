import {Component, OnInit, Input} from '@angular/core';
import {Router} from '@angular/router';
import {SportService} from "../../services/sport.service";
import {Sport} from "../../services/sport";
import {isNullOrUndefined} from "util";
import {Paths} from '../../paths';
import {ProfileApiClient} from "../../api/profile/profile-api-client";
import {User} from "../../services/user";
import {Profile} from "../../services/profile";
import {AccountService} from "../../services/account-service";

@Component({
  selector: 'header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  @Input() public isEmpty: false;

  sport: Sport;

  sports: Sport[];

  filteredCountriesSingle: Sport[];

  public currentProfile: Profile;

  constructor(private router: Router,
              private sportService: SportService,
              private profileApiClient: ProfileApiClient,
              private accountService: AccountService) {
    this.accountService.authStatusChanged.subscribe(async (isAuth) => {
      if (isAuth) {
        const profileResponse = await this.profileApiClient.getCurrentAsync();
        this.currentProfile = <Profile> {firstName: profileResponse.firstName, lastName: profileResponse.lastName};
      }
    });
  }

  async ngOnInit() {
    const response = await this.sportService.getAllAsync();
    this.sports = response.items;
    const profileResponse = await this.profileApiClient.getCurrentAsync();
    this.currentProfile = <Profile> {firstName: profileResponse.firstName, lastName: profileResponse.lastName};
  }

  async filterCountrySingle(event) {
    let query = event.query;
    this.filteredCountriesSingle = this.filterCountry(query, this.sports);
  }

  filterCountry(query, countries: Sport[]): Sport[] {
    //in a real application, make a request to a remote url with the query and return filtered results, for demo we filter at client side
    let filtered: Sport[] = [];
    for (let i = 0; i < countries.length; i++) {
      let country = countries[i];
      if (country.name.toLowerCase().indexOf(query.toLowerCase()) >= 0) {
        filtered.push(country);
      }
    }
    return filtered;
  }

  async loginAsync() {
    await this.router.navigate([Paths.Login]);
  }

  async registerAsync() {
    await this.router.navigate([Paths.SignUp]);
  }

  async submitAsync() {
    if (!isNullOrUndefined(this.sport.id)) {
      await this.router.navigate([Paths.Trainers + '/' + this.sport.id]);
    }
  }
}
