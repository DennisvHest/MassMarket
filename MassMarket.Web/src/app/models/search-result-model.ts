import { ProductCardModel } from './product-card-model';

export class SearchResultModel {
    products: ProductCardModel[];
    minPrice: number;
    maxPrice: number;
}
