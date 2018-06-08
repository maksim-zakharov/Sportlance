import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  startDate: number = 2018;

  endDate: number;

  @Input() public isEmpty: false;

  constructor() {
    this.endDate = (new Date()).getFullYear();
  }

  ngOnInit() {

  }

}
