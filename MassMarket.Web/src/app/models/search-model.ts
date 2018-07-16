export class SearchModel {
    queryText = '';
    categoryId = 0;

    constructor(searchModel: SearchModel) {
        if (searchModel) {
            this.queryText = searchModel.queryText;
            this.categoryId = searchModel.categoryId;
        }
    }
}
