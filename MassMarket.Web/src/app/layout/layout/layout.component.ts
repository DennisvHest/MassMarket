import { Component, OnInit } from '@angular/core';
import { FormControl } from '../../../../node_modules/@angular/forms';

@Component({
  selector: 'mm-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.less']
})
export class LayoutComponent implements OnInit {

  searchBox = new FormControl();

  constructor() { }

  ngOnInit() {
  }

}
