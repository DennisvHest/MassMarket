import { Component, OnInit, ViewChild } from '@angular/core';
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
  @ViewChild('brands') brands;

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

        // Make sure that metaFieldOptions from the URL query parameters are an array
        let metaFieldOptions;

        if (!params.metaFieldOptions) {
          metaFieldOptions = null;
        } else if (!params.metaFieldOptions.map) {
          metaFieldOptions = [params.metaFieldOptions];
        } else {
          metaFieldOptions = params.metaFieldOptions;
        }

        // Set the search option values to the values from the URL query parameters
        this.searchForm.setValue({
          queryText: params.queryText ? params.queryText : '',
          categoryId: params.categoryId ? +params.categoryId : 0,
          ordering: params.ordering ? +params.ordering : 0,
          pageNr: params.pageNr ? +params.pageNr : 1,
          priceRange: params.priceRange ? <number[]>params.priceRange : null,
          metaFieldOptions: metaFieldOptions ? metaFieldOptions.map((o) => parseInt(<any>o)) : null
        });

        this.search();
      });
  }

  createForm() {
    this.searchForm = this.formBuilder.group(new SearchModel(null));
  }

  search() {
    if (this.brands) {
      this.searchForm.patchValue({
        metaFieldOptions: this.brands.value
      });
    }

    const query = this.searchForm.value;

    // Change the URL query parameters to the current search query
    const url = this.router
      .createUrlTree([], { queryParams: query, relativeTo: this.route })
      .toString();

    this.location.go(url);

    this.searching = true;
    this.productService.search(query)
      .subscribe(result => {
        if (!this.searchForm.value.priceRange) {
          const params = <SearchModel>this.route.snapshot.queryParams;

          this.searchForm.patchValue({
            priceRange: params.priceRange ? params.priceRange : [result.minPrice, result.maxPrice]
          });
        }

        this.searchResult = result;
        this.searching = false;
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
