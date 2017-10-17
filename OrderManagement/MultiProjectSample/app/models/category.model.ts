// TODO: is there a way to improve this?
export type CategoryType = string;

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

export interface ICategory {
    categoryID: number;
    categoryName: string;
    description: string;
    picture: string;
}

export interface ICategoryList {
    items: {};
    loading: boolean;
    error: any;
}

