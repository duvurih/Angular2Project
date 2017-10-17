import "./rxjs-operators";

// standard Angular2 modules
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, ErrorHandler, Optional, SkipSelf  } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
// import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { LocationStrategy, HashLocationStrategy } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { Router, Resolve, RouterStateSnapshot, ActivatedRouteSnapshot } from "@angular/router";

// ng2-bootstrap
import { ModalModule } from "ng2-modal";
import { Ng2BootstrapModule, TypeaheadModule, ComponentLoaderFactory, PositioningService } from "ng2-bootstrap";
import { PaginationModule } from "ng2-bootstrap";
import { DatepickerModule } from "ng2-bootstrap";
// import { ModalModule } from "ng2-bootstrap";
import { ProgressbarModule } from "ng2-bootstrap";
import { TimepickerModule } from "ng2-bootstrap";
import { Ng2PageScrollModule } from "ng2-page-scroll";
import { Ng2TableModule } from "ng2-table/ng2-table";
import { AgmCoreModule } from "@agm/core";
import { ChartModule } from "angular2-highcharts";

// importing common components
import { TableComponent } from "./common/table.component";
import { ValidationMessages } from "./common/validation.component";
import { AutoCompleteComponent } from "./common/autocomplete.component";
import { LocationComponent } from "./common/location.component";

// importing pipe and directive components
import { NameFilterPipe, DateFormatPipe, SafeHtml } from "./common/pipe.component";
import { ProfileImageDirective } from "./common/directives.component";

// importing configurations
// import { CryptoComponent } from "./config/crypto.component";
import { routing } from "./config/routing.component";
import { GenericExceptionHandler } from "./config/exceptionhandler.component";

// shared services
import { AuthService } from "./services/auth.service";
import { AuthCheckActivator } from "./services/authcheck.service";
import { DataContextService } from "./services/datacontext.service";
import { ValidationService } from "./services/validation.service";
import { ReferenceDataService } from "./services/referencedata.service";

// layout components
import { SidebarComponent } from "./layout/sidebar/sidebar.component";
import { TopbarComponent } from "./layout/topbar/topbar.component";
import { WidgetComponent } from "./layout/widget/widget.component";
import { TabComponent } from "./layout/tabs/tab.component";
import { TabsComponent } from "./layout/tabs/tabs.component";

// application components
import { AppComponent } from "./app.component";
import { LoginComponent } from "./public/login/login.component";
import { DashboardComponent } from "./features/dashboard/dashboard.component";
import { ChartComponent } from "./features/dashboard/charts.component";

import { CategoryCatalogComponent } from "./features/category/categorycatalog.component";
import { CategoryItemComponent } from "./features/category/categoryitem.component";

import { ProductsListComponent } from "./features/product/productslist.component";
import { ViewProductComponent } from "./features/product/viewproduct.component";
import { ProductStatsComponent } from "./features/product/productstats.component";

import { CustomersListComponent } from "./features/customer/customerlist.component";
import { ViewCustomerComponent } from "./features/customer/viewcustomer.component";
import { CustomerSearchComponent } from "./features/customer/customersearch.component";
import { CustomerInfoComponent } from "./features/customer/customerinfo.component";
import { CustomersOnMapComponent } from "./features/customer/customersonmap.component";

import { SuppliersListComponent } from "./features/supplier/supplierlist.component";
import { ViewSupplierComponent } from "./features/supplier/viewsupplier.component";

import { OrdersListComponent } from "./features/order/orderlist.component";
import { ViewOrderComponent } from "./features/order/vieworder.component";
import { OrderDetailsListComponent } from "./features/order/orderdetaillist.component";
import { ViewOrderDetailComponent } from "./features/order/vieworderdetail.component";

// application specific services
import { ProductListResolverService } from "./features/product/productlist-resolver.service";
import { ProductResolverService } from "./features/product/product-resolver.service";
import { SupplierResolverService } from "./features/supplier/supplier-resolver.service";
import { CustomerResolverService } from "./features/customer/customer-resolver.service";
import { OrderResolverService } from "./features/order/order-resolver.service";

// importing application module data services
import { CategoryService } from "./features/category/services/category.service";

// importing module guard
import { throwIfAlreadyLoaded } from "./modules/module-import-guard";

// importing application modules
import { StoreModule } from "./redux/store.module";
declare var require: any;

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        DatepickerModule,
        AgmCoreModule.forRoot({ apiKey: 'AIzaSyA1vWp8aa0ohma7Zev45V7T2y5842aOh0I' }),
        Ng2BootstrapModule,
        Ng2TableModule,
        ModalModule,
        //ModalModule.forRoot(),
        TypeaheadModule,
        ProgressbarModule,
        PaginationModule.forRoot(),
        Ng2PageScrollModule.forRoot(),
        TimepickerModule,
        routing,
        StoreModule,
        ChartModule.forRoot(
            require('highcharts'),
            require('highcharts/modules/exporting')
        )
    ],
    declarations: [
        NameFilterPipe,
        DateFormatPipe,
        TableComponent,
        ValidationMessages,
        AutoCompleteComponent,
        SafeHtml,
        WidgetComponent,
        TabComponent,
        TabsComponent,
        AppComponent,
        LoginComponent,
        SidebarComponent,
        TopbarComponent,
        DashboardComponent,
        ChartComponent,
        CategoryCatalogComponent,
        CategoryItemComponent,
        ProfileImageDirective,
        ProductsListComponent,
        ViewProductComponent,
        ProductStatsComponent,
        CustomersListComponent,
        ViewCustomerComponent,
        CustomerSearchComponent,
        CustomerInfoComponent,
        CustomersOnMapComponent,
        SuppliersListComponent,
        ViewSupplierComponent,
        OrdersListComponent,
        ViewOrderComponent,
        OrderDetailsListComponent,
        ViewOrderDetailComponent,
        LocationComponent
    ],
    providers: [
        ComponentLoaderFactory,
        PositioningService,
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        AuthService,
        AuthCheckActivator,
        DataContextService,
        ValidationService,
        ReferenceDataService,
        { provide: ErrorHandler, useClass: GenericExceptionHandler },
        SupplierResolverService,
        ProductListResolverService,
        ProductResolverService,
        CustomerResolverService,
        OrderResolverService,
        CategoryService
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    bootstrap: [AppComponent]
})
export class AppModule {
    constructor(
        @Optional() @SkipSelf() parentModule: AppModule
    ) {
        throwIfAlreadyLoaded(parentModule, "AppModule");
    }
}