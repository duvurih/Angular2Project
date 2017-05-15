import './rxjs-operators';

// standard Angular2 modules
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

// ng2-bootstrap
import { Ng2BootstrapModule } from 'ng2-bootstrap';
import { PaginationModule } from 'ng2-bootstrap';
import { DatepickerModule } from 'ng2-bootstrap';
import { ModalModule } from 'ng2-bootstrap';
import { ProgressbarModule } from 'ng2-bootstrap';
import { TimepickerModule } from 'ng2-bootstrap';

// importing configurations
import { CryptoComponent } from './config/crypto.component';
import { routing } from './config/routing.component';

// shared services
import { AuthService } from './services/auth.service';
import { AuthCheckActivator } from './services/authcheck.service';
import { DataContextService } from './services/datacontext.service';

// application components
import { AppComponent } from './app.component';
import { LoginComponent } from './public/login/login.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { SidebarComponent } from './features/sidebar/sidebar.component';
import { TopbarComponent } from './features/topbar/topbar.component';
import { ProductsListComponent } from './features/product/productslist.component';
import { CategoryCatalogComponent } from './features/category/categorycatalog.component';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        DatepickerModule,
        Ng2BootstrapModule,
        ModalModule,
        ProgressbarModule,
        PaginationModule,
        TimepickerModule,
        routing
    ],
    declarations: [
        AppComponent,
        LoginComponent,
        DashboardComponent,
        SidebarComponent,
        TopbarComponent,
        ProductsListComponent,
        CategoryCatalogComponent
    ],
    providers: [
        AuthService,
        AuthCheckActivator,
        DataContextService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }