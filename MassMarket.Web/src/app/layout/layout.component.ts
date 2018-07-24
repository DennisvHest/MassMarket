import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { SearchModel } from '../models/search-model';
import { Router } from '../../../node_modules/@angular/router';

@Component({
  selector: 'mm-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.less']
})
export class LayoutComponent implements OnInit {

  navSearchForm: FormGroup;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router
  ) {
    this.navSearchForm = this.formBuilder.group(new SearchModel(null));
   }

  ngOnInit() {
  }

  onSearchSubmit() {
    this.router.navigate(['products', 'search'], {
      queryParams: {
        queryText: this.navSearchForm.controls['queryText'].value
      }
    });
  }
}
