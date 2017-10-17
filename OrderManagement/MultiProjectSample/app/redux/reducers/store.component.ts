// importing reducers
import { combineReducers } from "redux";
import { routerReducer } from "@angular-redux/router";

// importing state
import { IAppState } from "../app-state";

// importing actions
import { CategoryReducer } from "../../features/category/services/category.reducer";

// importing data models
import { CategoryModel, ICategory, ICategoryList, CategoryType } from "../../models/category.model";


export const rootReducer = combineReducers({
    categoriesRdx: CategoryReducer("categories")
});