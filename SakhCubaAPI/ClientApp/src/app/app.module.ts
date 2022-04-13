import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

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

const appRoutes: Routes = [
  {path: '', component: HomeComponent, pathMatch: 'full'},
  {path: 'news', component: NewsComponent, pathMatch: 'full'},
  {path: 'news/:id', component: NewsViewComponent},
  {path: 'rules', component: RulesComponent, pathMatch: 'full'},
  {path: 'application', component: ApplicationComponent, pathMatch: 'full'},
  //admin
  {path: 'admin', component: AdminComponent, pathMatch: 'full'},
  {path: 'admin/:id', component: AdminViewComponent},
  //news
  {path: 'admin/news', component: AdminNewsComponent, pathMatch: 'full'},
  {path: 'admin/news/:id', component: AdminNewsViewComponent},

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
    NotFoundComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
