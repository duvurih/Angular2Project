// importing category actions
import { CategoryAction, CategoryActions } from "./category.actions";

// importing data models
import { CategoryModel, ICategory, ICategoryList, CategoryType } from "../../../models/category.model";

const INITIAL_STATE: ICategoryList = {
    items: {},
    loading: false,
    error: null,
};

export function CategoryReducer(categoryType: CategoryType) {
    return function categoryReducer(state: ICategoryList = INITIAL_STATE, action: CategoryAction): ICategoryList {
        if (!action.meta || action.meta.categoryType != categoryType) {
            return state;
        }

        switch (action.type) {
            case CategoryActions.LOAD_STARTED:
                return {
                    ...state,
                    items: {},
                    loading: true,
                    error: null,
                };
            case CategoryActions.LOAD_SUCCEEDED:
                return {
                    ...state,
                    items: action.payload,
                    loading: false,
                    error: null,
                };
            case CategoryActions.LOAD_FAILED:
                return {
                    ...state,
                    items: {},
                    loading: false,
                    error: action.error,
                };
        }
    }
}