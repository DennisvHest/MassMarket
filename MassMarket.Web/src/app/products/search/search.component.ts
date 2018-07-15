import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import { SearchOptions } from '../../models/search-options';

@Component({
  selector: 'mm-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.less']
})
export class SearchComponent implements OnInit {

  searchOptions: SearchOptions;

  constructor(private productService: ProductService) { }

  ngOnInit() {
    this.productService.getSearchOptions()
      .subscribe(searchOptions => {
        this.searchOptions = searchOptions;
      });
  }
}
