﻿import { Injectable } from "@angular/core";
import { dispatch } from "@angular-redux/store";
import { FluxStandardAction } from "flux-standard-action";

// importing data models
import { CategoryModel, ICategory, ICategoryList, CategoryType } from "../../models/category.model";

// flux-standard-action gives us stronger typing of our actions.
type Payload = ICategory[];
interface MetaData { categoryType: CategoryType; };
export type GeneralAction = FluxStandardAction<Payload, MetaData>;

@Injectable()
export class GeneralActions {
    static readonly LOAD_ALL = "LOAD_ALL";
    static readonly LOAD_STARTED = "LOAD_STARTED";
    static readonly LOAD_SUCCEEDED = "LOAD_SUCCEEDED";
    static readonly LOAD_FAILED = "LOAD_FAILED";

    @dispatch()
    loadCategories = (categoryType: CategoryType): GeneralAction => ({
        type: GeneralActions.LOAD_ALL,
        meta: { categoryType },
        payload: null
    });

    loadStarted = (categoryType: CategoryType): GeneralAction => ({
        type: GeneralActions.LOAD_STARTED,
        meta: { categoryType },
        payload: null,
    })

    loadSucceeded = (categoryType: CategoryType, payload: Payload): GeneralAction => ({
        type: GeneralActions.LOAD_SUCCEEDED,
        meta: { categoryType },
        payload,
    })

    loadFailed = (categoryType: CategoryType, error: any): GeneralAction => ({
        type: GeneralActions.LOAD_FAILED,
        meta: { categoryType },
        payload: null,
        error,
    })
}