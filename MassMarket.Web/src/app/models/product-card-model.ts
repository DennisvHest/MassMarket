import { Category } from './category';

export class ProductCardModel {
    id: number;
    name: string;
    description: string;
    price: number;
    brand: string;
    image: string;

    category: Category;
}
