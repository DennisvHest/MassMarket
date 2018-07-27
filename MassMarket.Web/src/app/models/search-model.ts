export class SearchModel {
    queryText = null;
    categoryId = 0;
    minPrice = null;
    maxPrice = null;
    ordering = 0;
    pageNr = 1;

    constructor(searchModel: SearchModel) {
        if (searchModel) {
            this.queryText = searchModel.queryText;
            this.categoryId = searchModel.categoryId;
            this.minPrice = searchModel.minPrice;
            this.maxPrice = searchModel.maxPrice;
            this.ordering = searchModel.ordering;
            this.pageNr = searchModel.pageNr;
        }
    }
}
