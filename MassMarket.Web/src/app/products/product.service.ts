import { Injectable } from '@angular/core';
import { SearchOptions } from '../models/search-options';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { SearchModel } from '../models/search-model';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private static productsUrl = 'api/products';

  constructor(private http: HttpClient) { }

  getSearchOptions(): Observable<SearchOptions> {
    return this.http.get<SearchOptions>(`${ProductService.productsUrl}/searchoptions`);
  }

  search(query: SearchModel) {
    return this.http.get<Product[]>(`${ProductService.productsUrl}/search`, {
      params: <any>query
    });
  }
}
