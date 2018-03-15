import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA, NO_ERRORS_SCHEMA } from '@angular/core';

import { CurrencyMaskModule } from './shared/modules/ng2-currency-mask';

import { CalendarModule } from 'primeng/primeng';
import { CheckboxModule } from 'primeng/primeng';
import { DataTableModule, SharedModule } from 'primeng/primeng';
import { FileUploadModule } from 'primeng/primeng';
import { ListboxModule } from 'primeng/primeng';
import { InputMaskModule } from 'primeng/primeng';
import { MultiSelectModule } from 'primeng/primeng';
import { ToggleButtonModule } from 'primeng/primeng';

import * as moment from 'moment';

import { AlertModule } from 'ngx-bootstrap/ng2-bootstrap';
import { ModalModule } from 'ngx-bootstrap/ng2-bootstrap';
import { TooltipModule } from 'ngx-bootstrap/ng2-bootstrap';

import { ApiService } from './shared/services/api.service';
import { NavigateblockerService } from './shared/services/navigateblocker.service';
import { NotificationsService } from './shared/services/notifications.service';
import { WindowRefService } from './shared/services/window-ref.service';

import { AppComponent } from './app.component';
import { AlertComponent } from './shared/components/alert/alert.component';
import { CustomersComponent } from './view/customers/customers.component';
import { LoginComponent } from './login/login.component';
import { BusyComponent } from './shared/components/busy/busy.component';
import { DownloaderComponent } from './shared/components/downloader/downloader.component';
import { LockboxComponent } from './shared/components/lockbox/lockbox.component';
import { ModalComponent } from './shared/components/modal/modal.component';
import { RefreshHelperComponent } from './shared/components/refresh-helper/refresh-helper.component';
import { SplashComponent } from './splash/splash.component';
import { SwitchComponent } from './shared/components/switch/switch.component';
import { VersionComponent } from './shared/components/version/version.component';
import { ViewblockComponent } from './view/viewblock/viewblock.component';

import { ParensToMinusPipe } from './shared/pipes/parens-to-minus.pipe';
import { FocusMeDirective } from './shared/directives/focus-me.directive';
import { VtxDatePipe } from './shared/pipes/vtx-date.pipe';

let routes = [
    { path: "", component: SplashComponent },
    { path: "customers", component: CustomersComponent },
    { path: "login", component: LoginComponent }

];

@NgModule({
    declarations: [
        AppComponent,
        AlertComponent,
	    CustomersComponent,
        BusyComponent,
        DownloaderComponent,
        FocusMeDirective,
        LockboxComponent,
        ModalComponent,
        ParensToMinusPipe,
        RefreshHelperComponent,
        SplashComponent,
        LoginComponent,
        SwitchComponent,
        VersionComponent,
        ViewblockComponent,
        VtxDatePipe
    ],
    exports: [VersionComponent],
    imports: [
        AlertModule.forRoot(),
        BrowserModule,
        BrowserAnimationsModule,
        CalendarModule,
        CheckboxModule,
        CurrencyMaskModule,
        DataTableModule,
        FileUploadModule,
        FormsModule,
        HttpClientModule,
        InputMaskModule,
        ListboxModule,
        ModalModule.forRoot(),
        MultiSelectModule,
        ReactiveFormsModule,
        SharedModule,
        ToggleButtonModule,
        TooltipModule.forRoot(),
        RouterModule.forRoot(routes)
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    providers: [ApiService,
        NavigateblockerService,
        NotificationsService,
        WindowRefService
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }

