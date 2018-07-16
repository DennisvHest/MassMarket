export class CategoryOption {
    id: number;
    name: string;
    childCategories: CategoryOption[];

    constructor(id: number, name: string) {
        this.id = id;
        this.name = name;
    }
}
