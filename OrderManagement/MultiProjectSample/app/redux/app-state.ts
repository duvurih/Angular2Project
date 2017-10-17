// importing data models
import { CategoryModel, ICategory, ICategoryList } from "../models/category.model";
import { SupplierModel } from "../models/supplier.model";

export interface IAppState {
    categories?: ICategoryList;
}