export class SearchModel {
    queryText = null;
    categoryId = 0;
    minPrice = null;
    maxPrice = null;

    constructor(searchModel: SearchModel) {
        if (searchModel) {
            this.queryText = searchModel.queryText;
            this.categoryId = searchModel.categoryId;
            this.minPrice = searchModel.minPrice;
            this.maxPrice = searchModel.maxPrice;
        }
    }
}
