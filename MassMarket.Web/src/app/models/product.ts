import { Category } from './category';

export class Product {
    id: number;
    name: string;
    description: string;
    image: string;

    category: Category;
}
