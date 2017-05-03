import './rxjs-operators'

//Standard Angular2 modules
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

//ng2-bootstrap
import { Ng2BootstrapModule } from 'ngx-bootstrap/ng2-bootstrap';
import { PaginationModule } from 'ngx-bootstrap/ng2-bootstrap';
import { DatepickerModule } from 'ngx-bootstrap/ng2-bootstrap';
import { ModalModule } from 'ngx-bootstrap/ng2-bootstrap';
import { ProgressbarModule } from 'ngx-bootstrap/ng2-bootstrap';
import { TimepickerModule } from 'ngx-bootstrap/ng2-bootstrap';

//Importing configurations
import { CryptoComponent } from './config/crypto.component';
import { routing } from './config/routing.component';

//Shared services
import { AuthService } from './services/auth.service';
import { AuthCheckActivator } from './services/authcheck.service';
import { DataContextService } from './services/datacontext.service';

//Application Components
import { AppComponent } from './app.component';
import { LoginComponent } from './public/login/login.component';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { SidebarComponent } from './features/sidebar/sidebar.component';
import { TopbarComponent } from './features/topbar/topbar.component';
import { ProductsListComponent } from './features/product/productslist.component';

@NgModule({
    imports: [
        BrowserModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        //DatepickerModule,
        //Ng2BootstrapModule,
        //ModalModule,
        //ProgressbarModule,
        //PaginationModule,
        //TimepickerModule,
        routing
    ],
    declarations: [
        AppComponent,
        LoginComponent,
        DashboardComponent,
        SidebarComponent,
        TopbarComponent,
        ProductsListComponent
    ],
    providers: [
        AuthService,
        AuthCheckActivator,
        DataContextService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }