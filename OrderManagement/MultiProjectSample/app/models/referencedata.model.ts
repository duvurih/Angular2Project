import {CategoryModel } from "../models/category.model";
import { ProductModel } from "../models/product.model";
import { SupplierModel } from "../models/supplier.model";

export class ReferenceData {
    public categorys: CategoryModel[];
    public products: ProductModel[];
    public suppliers: SupplierModel[];
}