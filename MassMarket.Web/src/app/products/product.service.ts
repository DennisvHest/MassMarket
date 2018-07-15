import { Injectable } from '@angular/core';
import { SearchOptions } from '../models/search-options';
import { Observable } from '../../../node_modules/rxjs';
import { HttpClient } from '../../../node_modules/@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private static productsUrl = 'api/products';

  constructor(private http: HttpClient) { }

  getSearchOptions(): Observable<SearchOptions> {
    return this.http.get<SearchOptions>(`${ProductService.productsUrl}/searchoptions`);
  }
}
