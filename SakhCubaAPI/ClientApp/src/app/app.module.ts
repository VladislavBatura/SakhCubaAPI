import { BrowserModule } from '@angular/platform-browser';
import { NgModule, Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { NewsViewComponent } from './news-view/news-view.component';
import { NewsComponent } from './news/news.component';
import { ApplicationComponent } from './application/application.component';
import { AdminComponent } from './admin/admin.component';
import { AdminViewComponent } from './admin-view/admin-view.component';
import { AdminNewsComponent } from './admin-news/admin-news.component';
import { AdminNewsViewComponent } from './admin-news-view/admin-news-view.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RulesComponent } from './rules/rules.component';
import { LoginComponent } from './login/login.component';
import { AdminGetResolver } from './Resolvers/admingetall.resolver';
import { AuthInterceptor } from './auth.interceptor';
import { AdminGetOneResolver } from './Resolvers/admin-get-one.resolver';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

const appRoutes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'news', component: NewsComponent, pathMatch: 'full'},
  {path: 'news/:id', component: NewsViewComponent, pathMatch: 'full'},
  {path: 'rules', component: RulesComponent, pathMatch: 'full'},
  {path: 'application', component: ApplicationComponent, pathMatch: 'full'},
  {path: 'login', component: LoginComponent, pathMatch: 'full'},
  //news
  {path: 'admin/news', component: AdminNewsComponent, pathMatch: 'full'},
  {path: 'admin/news/:id', component: AdminNewsViewComponent, pathMatch: 'full'},
  //admin
  {path: 'admin', component: AdminComponent, pathMatch: 'full', resolve: {
    adminGet: AdminGetResolver
  }},
  {path: 'admin/:id', component: AdminViewComponent, pathMatch: 'full', resolve: {adminGetOne: AdminGetOneResolver}},
  

  {path: '**', component: NotFoundComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    NewsViewComponent,
    NewsComponent,
    ApplicationComponent,
    AdminComponent,
    AdminViewComponent,
    AdminNewsComponent,
    AdminNewsViewComponent,
    RulesComponent,
    NotFoundComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
