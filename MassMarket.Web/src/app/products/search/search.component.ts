import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ProductService } from '../product.service';
import { SearchOptions } from '../../models/search-options';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CategoryOption } from '../../models/category-option';
import { SearchModel } from '../../models/search-model';
import { ProductCardModel } from '../../models/product-card-model';
import { Router, Params, ParamMap, ActivatedRoute } from '@angular/router';
import { SearchResultModel } from '../../models/search-result-model';

@Component({
  selector: 'mm-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.less']
})
export class SearchComponent implements OnInit {

  searchOptions: SearchOptions;
  searchResult: SearchResultModel;

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
    this.route.queryParams.subscribe(() => {
      this.getSearchOptions();
    });

    this.getSearchOptions();
  }

  private getSearchOptions() {
    this.productService.getSearchOptions()
    .subscribe(searchOptions => {
      searchOptions.categories.unshift(new CategoryOption(0, 'All Categories'));
      this.searchOptions = searchOptions;

      const params = <SearchModel>this.route.snapshot.queryParams;

      this.searchForm.setValue({
        queryText: params.queryText ? params.queryText : '',
        categoryId: params.categoryId ? +params.categoryId : 0,
        minPrice: params.minPrice ? +params.minPrice : null,
        maxPrice: params.maxPrice ? +params.maxPrice : null
      });

      if (!params.minPrice) {
        this.searchForm.controls['minPrice'].disable();
      }

      if (!params.maxPrice) {
        this.searchForm.controls['maxPrice'].disable();
      }

      this.search();
    });
  }

  createForm() {
    this.searchForm = this.formBuilder.group(new SearchModel(null));
  }

  search() {
    const query = this.searchForm.value;

    if (query.minPrice === 0 && query.maxPrice === 0) {
      query.minPrice = null;
      query.maxPrice = null;
    }

    const url = this.router
      .createUrlTree([], { queryParams: query, relativeTo: this.route })
      .toString();

    this.location.go(url);

    this.searching = true;
    this.productService.search(query)
      .subscribe(foundProducts => {
        this.searchResult = foundProducts;
        this.searching = false;
        this.searchForm.controls['minPrice'].enable();
        this.searchForm.controls['maxPrice'].enable();
      });
  }
}
