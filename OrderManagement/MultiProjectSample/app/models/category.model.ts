export class CategoryModel {
    categoryID: number;
    categoryName: string;
    description: string;
    picture: string;

    constructor(categoryData: any) {
        this.categoryID = categoryData.categoryID;
        this.categoryName = categoryData.categoryName;
        this.description = categoryData.description;
        this.picture = categoryData.picture;
    }
}