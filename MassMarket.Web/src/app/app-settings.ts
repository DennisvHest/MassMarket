import { Product } from './models/product';

export class AppSettings {

    public static productImagePath(product: Product): string {
        return product.image
            ? product.image
            : 'http://via.placeholder.com/600x400/ffffff/3f51b5?text=No%20image!';
    }
}
