import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SummaryPipe } from './pipes/summary.pipe';
import { BlogComponent } from './components/blog-components/blog/blog.component';
import { BlogCardComponent } from './components/blog-components/blog-card/blog-card.component';
import { BlogEditComponent } from './components/blog-components/blog-edit/blog-edit.component';
import { BlogsComponent } from './components/blog-components/blogs/blogs.component';
import { FamousBlogsComponent } from './components/blog-components/famous-blogs/famous-blogs.component';
import { CommentBoxComponent } from './components/comment-components/comment-box/comment-box.component';
import { CommentsComponent } from './components/comment-components/comments/comments.component';
import { CommentSystemComponent } from './components/comment-components/comment-system/comment-system.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HomeComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PhotoAlbumComponent } from './components/photo-album/photo-album.component';
import { RegisterComponent } from './components/register/register.component';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { ErrorInterceptor } from './interceptors/error.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    SummaryPipe,
    BlogComponent,
    BlogCardComponent,
    BlogEditComponent,
    BlogsComponent,
    FamousBlogsComponent,
    CommentBoxComponent,
    CommentsComponent,
    CommentSystemComponent,
    DashboardComponent,
    HomeComponent,
    LoginComponent,
    NavbarComponent,
    NotFoundComponent,
    PhotoAlbumComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right'
    }),
  ],
  providers: [
    HttpClient,
    {provide : HTTP_INTERCEPTORS, useClass:JwtInterceptor,multi:true},
    {provide : HTTP_INTERCEPTORS, useClass:ErrorInterceptor,multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
