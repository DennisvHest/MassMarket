import { Component, OnInit } from '@angular/core';
import { ProductCardComponent } from '../product-card/product-card.component';

@Component({
  selector: 'mm-product-list-item',
  templateUrl: './product-list-item.component.html',
  styleUrls: ['./product-list-item.component.less']
})
export class ProductListItemComponent extends ProductCardComponent implements OnInit {

  constructor() {
    super();
  }

  ngOnInit() {
  }

}
