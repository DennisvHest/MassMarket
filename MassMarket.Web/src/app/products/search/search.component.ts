import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ProductService } from '../product.service';
import { SearchOptions } from '../../models/search-options';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CategoryOption } from '../../models/category-option';
import { SearchModel } from '../../models/search-model';
import { Product } from '../../models/product';
import { Router, Params, ParamMap, ActivatedRoute } from '../../../../node_modules/@angular/router';

@Component({
  selector: 'mm-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.less']
})
export class SearchComponent implements OnInit {

  searchOptions: SearchOptions;
  foundProducts: Product[];

  searchForm: FormGroup;

  searching: boolean;

  constructor(
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private location: Location,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.createForm();
  }

  ngOnInit() {
    this.productService.getSearchOptions()
      .subscribe(searchOptions => {
        searchOptions.categories.unshift(new CategoryOption(0, 'All Categories'));
        this.searchOptions = searchOptions;

        const params = <SearchModel>this.route.snapshot.queryParams;

        this.searchForm.setValue({
          queryText: params.queryText ? params.queryText : '',
          categoryId: params.categoryId ? +params.categoryId : 0
        });

        this.search();
      });
  }

  createForm() {
    this.searchForm = this.formBuilder.group(new SearchModel(null));
  }

  search() {
    const query = this.searchForm.value;

    const url = this.router
      .createUrlTree([], { queryParams: query, relativeTo: this.route })
      .toString();

    this.location.go(url);

    this.searching = true;
    this.productService.search(query)
      .subscribe(foundProducts => {
        this.foundProducts = foundProducts;
        this.searching = false;
      });
  }
}
