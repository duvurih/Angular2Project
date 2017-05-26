import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

import { LoginComponent } from "../public/login/login.component";
import { DashboardComponent } from "../features/dashboard/dashboard.component";
// import { AuthCheckActivator } from "../services/authcheck.service";
import { ProductsListComponent } from "../features/product/productslist.component";
import { CategoryCatalogComponent } from "../features/category/categorycatalog.component";
import { ViewProductComponent } from "../features/product/viewproduct.component";
import { CustomersListComponent } from "../features/customer/customerlist.component";
import { SuppliersListComponent } from "../features/supplier/supplierlist.component";
import { ViewSupplierComponent } from "../features/supplier/viewsupplier.component";

const mainRoutes: Routes = [
    { path: "login", component: LoginComponent},
    { path: "dashboard", component: DashboardComponent},
    { path: "viewProductsList", component: ProductsListComponent },
    { path: "viewCategoryProducts/:id", component: ProductsListComponent },
    { path: "viewProduct/:id", component: ViewProductComponent },
    { path: "viewCustomersList", component: CustomersListComponent },
    { path: "viewSuppliersList", component: SuppliersListComponent },
    { path: "viewSupplier/:id", component: ViewSupplierComponent },

    // redirects
    // { path: "", redirectTo: "/dashboard", pathMatch: "full"},
    { path: "**", component: CategoryCatalogComponent }
];

const childRoutes: Routes = [
];

const appRoutes: Routes = [
    ...mainRoutes,
    ...childRoutes
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);