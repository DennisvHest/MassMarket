import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { ProductService } from '../product.service';
import { SearchOptions } from '../../models/search-options';
import { FormGroup, FormBuilder } from '@angular/forms';
import { CategoryOption } from '../../models/category-option';
import { SearchModel } from '../../models/search-model';
import { Router, ActivatedRoute } from '@angular/router';
import { SearchResultModel } from '../../models/search-result-model';
import { ProductOrdering } from '../../models/product-ordering';
import { PageEvent } from '../../../../node_modules/@angular/material';

export enum ProductView {
  Grid,
  List
}

@Component({
  selector: 'mm-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.less']
})
export class SearchComponent implements OnInit {

  searchOptions: SearchOptions;
  searchResult: SearchResultModel;
  ProductOrdering = ProductOrdering;

  searchForm: FormGroup;

  searching: boolean;

  ProductView = ProductView;
  currentView: ProductView;

  constructor(
    private productService: ProductService,
    private formBuilder: FormBuilder,
    private location: Location,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.currentView = ProductView.Grid;
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

      // Set the search option values to the values from the URL query parameters
      this.searchForm.setValue({
        queryText: params.queryText ? params.queryText : '',
        categoryId: params.categoryId ? +params.categoryId : 0,
        minPrice: params.minPrice ? +params.minPrice : null,
        maxPrice: params.maxPrice ? +params.maxPrice : null,
        ordering: params.ordering ? +params.ordering : 0,
        pageNr: params.pageNr ? +params.pageNr : 1
      });

      // Disable minPrice and maxPrice until initial search is complete
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

    // Change the URL query parameters to the current search query
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

  changeView(view: ProductView) {
    this.currentView = view;
  }

  onOrderingChange(value) {
    this.searchForm.patchValue({
      ordering: value
    });

    this.search();
  }

  onPageChange(event: PageEvent) {
    this.searchForm.patchValue({
      pageNr: event.pageIndex + 1
    });

    this.search();
  }
}
