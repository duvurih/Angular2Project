import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { LoginComponent } from "../public/login/login.component";
import { DashboardComponent } from "../features/dashboard/dashboard.component";
// import { AuthCheckActivator } from "../services/authcheck.service";
import { ProductsListComponent } from "../features/product/productslist.component";
import { CategoryCatalogComponent } from "../features/category/categorycatalog.component";

const mainRoutes: Routes = [
    { path: "login", component: LoginComponent},
    { path: "dashboard", component: DashboardComponent},
    { path: "viewProductsList", component: ProductsListComponent },
    // redirects
    // { path: "", redirectTo: "/dashboard", pathMatch: "full"},
    { path: "**", component: CategoryCatalogComponent }
];

const appRoutes: Routes = [
    ...mainRoutes
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);