// importing angular components
import { ModuleWithProviders } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";

// importing application components
// import { LoginComponent } from "../public/login/login.component";
// import { AuthCheckActivator } from "../services/authcheck.service";
import { DashboardComponent } from "../features/dashboard/dashboard.component";

import { CategoryCatalogComponent } from "../features/category/categorycatalog.component";

import { ProductsListComponent } from "../features/product/productslist.component";
import { ViewProductComponent } from "../features/product/viewproduct.component";

import { CustomersListComponent } from "../features/customer/customerlist.component";
import { ViewCustomerComponent } from "../features/customer/viewcustomer.component";
import { CustomersOnMapComponent } from "../features/customer/customersonmap.component";

import { SuppliersListComponent } from "../features/supplier/supplierlist.component";
import { ViewSupplierComponent } from "../features/supplier/viewsupplier.component";

import { OrdersListComponent } from "../features/order/orderlist.component";
import { ViewOrderComponent } from "../features/order/vieworder.component";

// importing application specific services
import { ProductListResolverService } from "../features/product/productlist-resolver.service";
import { ProductResolverService } from "../features/product/product-resolver.service";
import { SupplierResolverService } from "../features/supplier/supplier-resolver.service";
import { CustomerResolverService } from "../features/customer/customer-resolver.service";
import { OrderResolverService } from "../features/order/order-resolver.service";


const mainRoutes: Routes = [
    // { path: "login", component: LoginComponent},
    { path: "dashboard", component: DashboardComponent},
    { path: "viewCategories", component: CategoryCatalogComponent },
    { path: "viewProductsList", component: ProductsListComponent, resolve: { products: ProductListResolverService} },
    { path: "viewCategoryProducts/:id", component: ProductsListComponent },
    { path: "viewProduct/:id", component: ViewProductComponent, resolve: { product: ProductResolverService} },
    { path: "viewCustomersList", component: CustomersListComponent },
    { path: "viewCustomer/:id", component: ViewCustomerComponent, resolve: { customer: CustomerResolverService } },
    { path: "customerOnMap", component: CustomersOnMapComponent},
    { path: "viewSuppliersList", component: SuppliersListComponent },
    { path: "viewSupplier/:id", component: ViewSupplierComponent, resolve: { supplier: SupplierResolverService } },
    { path: "viewOrdersList", component: OrdersListComponent },
    { path: "viewOrder/:id", component: ViewOrderComponent, resolve: { order: OrderResolverService }},


    // redirects
    { path: "", redirectTo: "/dashboard", pathMatch: "full"},
    { path: "**", component: DashboardComponent }
];

const childRoutes: Routes = [
];

const appRoutes: Routes = [
    ...mainRoutes,
    ...childRoutes
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);