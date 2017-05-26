import "./rxjs-operators";

// standard Angular2 modules
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, ErrorHandler, Optional, SkipSelf  } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
// import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";
import { LocationStrategy, HashLocationStrategy } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";

// ng2-bootstrap
import { Ng2BootstrapModule } from "ng2-bootstrap";
import { PaginationModule } from "ng2-bootstrap";
import { DatepickerModule } from "ng2-bootstrap";
import { ModalModule } from "ng2-bootstrap";
import { ProgressbarModule } from "ng2-bootstrap";
import { TimepickerModule } from "ng2-bootstrap";
import { Ng2PageScrollModule } from "ng2-page-scroll";

// importing common components
import { TableComponent } from "./common/table.component";
import { ValidationMessages } from "./common/validation.component";

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

// application components
import { AppComponent } from "./app.component";
import { LoginComponent } from "./public/login/login.component";
import { DashboardComponent } from "./features/dashboard/dashboard.component";
import { SidebarComponent } from "./features/sidebar/sidebar.component";
import { TopbarComponent } from "./features/topbar/topbar.component";
import { ProductsListComponent } from "./features/product/productslist.component";
import { CategoryCatalogComponent } from "./features/category/categorycatalog.component";
import { CategoryItemComponent } from "./features/category/categoryitem.component";
import { ViewProductComponent } from "./features/product/viewproduct.component";
import { CustomersListComponent } from "./features/customer/customerlist.component";
import { SuppliersListComponent } from "./features/supplier/supplierlist.component";
import { ViewSupplierComponent } from "./features/supplier/viewsupplier.component";

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        DatepickerModule,
        Ng2BootstrapModule,
        ModalModule.forRoot(),
        ProgressbarModule,
        PaginationModule.forRoot(),
        Ng2PageScrollModule.forRoot(),
        TimepickerModule,
        routing
    ],
    declarations: [
        NameFilterPipe,
        DateFormatPipe,
        TableComponent,
        ValidationMessages,
        AppComponent,
        LoginComponent,
        DashboardComponent,
        SidebarComponent,
        TopbarComponent,
        ProductsListComponent,
        CategoryCatalogComponent,
        CategoryItemComponent,
        SafeHtml,
        ProfileImageDirective,
        ViewProductComponent,
        CustomersListComponent,
        SuppliersListComponent,
        ViewSupplierComponent
    ],
    providers: [
        { provide: LocationStrategy, useClass: HashLocationStrategy },
        AuthService,
        AuthCheckActivator,
        DataContextService,
        ValidationService,
        ReferenceDataService,
        { provide: ErrorHandler, useClass: GenericExceptionHandler }

    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    bootstrap: [AppComponent]
})
export class AppModule {
    constructor( @Optional() @SkipSelf() parentModule: AppModule) {
        // throwIfAlreadyLoaded(parentModule, "AppModule")
    }
}