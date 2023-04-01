import { NgModule, isDevMode } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // this is needed!
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { SidebarModule } from './sidebar/sidebar.module';
import { FixedPluginModule } from './shared/fixedplugin/fixedplugin.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule } from './shared/navbar/navbar.module';
import { PagesnavbarModule } from './shared/pagesnavbar/pagesnavbar.module';
import { AdminLayoutComponent } from './layouts/admin/admin-layout.component';
import { AuthLayoutComponent } from './layouts/auth/auth-layout.component';
import { AppRoutes } from './app.routing';
import { HttpClientModule } from '@angular/common/http';
import { AuthService } from './services/auth/auth.service';
import { AuthGuard } from './services/auth/auth-guard.service';
import { AdminAuthGuard } from './services/auth/admin-auth-guard.service';
import { MedicalAuthGuard } from './services/auth/medical-auth-guard.service';
import { PatientAuthGuard } from './services/auth/patient-auth-guard.service';
import { CountDownTimerComponent } from './common/countdowntimer/countdowntimer.component';
import { CustomTextActivePipe } from './common/custompipe/customtextactive.pipe';
import { GenericDataTableGrid } from './components/genericdatatablegrid/genericdatatablegrid.component';
import { LayoutModule } from './custommodules/layout.module';
 
//import { StoreDevtoolsModule } from '@ngrx/store-devtools';
//import { GenderService } from './services/general/gender.service';
/*import { StoreModule } from '@ngrx/store';
import { createEntityReducer } from './storeredux/reducers/serviceresponse.reducer';
import { SpecialtyModel } from './models/simplemodel/SpecialtyModel';
import { EffectsModule } from '@ngrx/effects';
import { appReducer } from './storeredux/shared/app.reducer';
 */
@NgModule({
    imports: [
        BrowserAnimationsModule,

        RouterModule.forRoot(AppRoutes, {
            useHash: false//HashLocationStrategy- default true https://www.tektutorialshub.com/angular/angular-location-strategies/
        }),
        LayoutModule,
        FixedPluginModule,
        HttpClientModule,
        //EffectsModule.forRoot([]),
        //StoreDevtoolsModule.instrument({ maxAge: 25, logOnly: !isDevMode() }),
       // StoreModule.forRoot({ appState: appReducer }),
        //EffectsModule.forRoot([]),
       //StoreModule.forRoot({ specialty: createEntityReducer<SpecialtyModel> }),
        //EffectsModule.forFeature([SpecialtyEffect])
    ],
    declarations: [
        AppComponent,
        AdminLayoutComponent,
        AuthLayoutComponent,
        CountDownTimerComponent
    ],
    bootstrap: [AppComponent],
    providers: [
        //GenderService
        AuthService, AuthGuard, AdminAuthGuard, MedicalAuthGuard, PatientAuthGuard
    ],
})

export class AppModule { }
