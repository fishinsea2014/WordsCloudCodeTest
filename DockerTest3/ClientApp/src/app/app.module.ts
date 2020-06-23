import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule,ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { WordCloudComponent } from './word-cloud/word-cloud.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatFormFieldModule, MatInputModule, MatButtonModule} from "@angular/material";
import { TagCloudModule } from "angular-tag-cloud-module";
import { AdminComponent } from './admin/admin.component';

@NgModule({
   declarations: [
      AppComponent,
      NavMenuComponent,
      HomeComponent,
      WordCloudComponent,
      //MatInputModule,
      AdminComponent
   ],
   imports: [      
      HttpClientModule,
      FormsModule,
      MatFormFieldModule,
      ReactiveFormsModule,
      MatInputModule,
      MatButtonModule,
      TagCloudModule,      
      RouterModule.forRoot([
        { path: '', component: HomeComponent, pathMatch: 'full' },
        { path: 'word-cloud', component: WordCloudComponent },
        { path: 'admin', component: AdminComponent },
      ]),
      BrowserAnimationsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
