// importing angular core module
import { NgModule } from "@angular/core";
import { NgRedux, NgReduxModule, DevToolsExtension } from "@angular-redux/store";
import { NgReduxRouterModule, NgReduxRouter } from '@angular-redux/router';
// import { provideReduxForms } from '@angular-redux/form';

// application store and reducers
import { IAppState } from "./app-state";
import { rootReducer } from "./reducers/store.component";

@NgModule({
    imports: [
        NgReduxModule,
        NgReduxRouterModule
    ],
    providers:[]
})
export class StoreModule {
    constructore(
        ngRedux: NgRedux<IAppState>,
        devTools: DevToolsExtension,
        ngReduxRouter: NgReduxRouter,
    ) {
        let middlewares: any = [];
        let enhancers: any = [];
        enhancers.push(devTools.enhancer());

        ngRedux.configureStore(
            rootReducer,
            {},
            middlewares,
            enhancers
        );

        // Enable syncing of Angular router state with our Redux store.
        if (ngReduxRouter) {
            ngReduxRouter.initialize();
        }

        // Enable syncing of Angular form state with our Redux store.
       // provideReduxForms(ngRedux);
    }
}