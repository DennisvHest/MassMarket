import { Component, OnInit, Input } from '@angular/core';
import { ProductCardModel } from '../../models/product-card-model';
import { AppSettings } from '../../app-settings';

@Component({
  selector: 'mm-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.less']
})
export class ProductCardComponent implements OnInit {

  @Input('product') product: ProductCardModel;

  constructor() { }

  ngOnInit() {
  }

  get imageUrl(): string {
    return AppSettings.productImagePath(this.product);
  }
}
