export class SearchModel {
    queryText = null;
    categoryId = 0;
    ordering = 0;
    pageNr = 1;
    priceRange: number[] = [];
    metaFieldOptions: number[] = [];

    constructor(searchModel: SearchModel) {
        if (searchModel) {
            this.queryText = searchModel.queryText;
            this.categoryId = searchModel.categoryId;
            this.ordering = searchModel.ordering;
            this.pageNr = searchModel.pageNr;
            this.priceRange = searchModel.priceRange;
            this.metaFieldOptions = searchModel.metaFieldOptions;
        }
    }
}
