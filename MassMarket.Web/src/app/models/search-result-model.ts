import { ProductCardModel } from './product-card-model';
import { MetaFieldOotionModel } from './meta-field-option-model';

export class SearchResultModel {
    products: ProductCardModel[];
    brandOptions: MetaFieldOotionModel[];
    minPrice: number;
    maxPrice: number;
    totalProductCount: number;
}
