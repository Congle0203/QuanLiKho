// import { BrowserModule } from '@angular/platform-browser';
// import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
// import { NgModule } from '@angular/core';
// import { FormsModule } from '@angular/forms';
// import { HttpClientModule } from '@angular/common/http';
// import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';
// import { AppComponent } from './app.component';

// /** config angular i18n **/
// import { registerLocaleData } from '@angular/common';
// import en from '@angular/common/locales/en';
// import { AppRoutingModule } from './app-routing.module';
// registerLocaleData(en);

// @NgModule({
//   declarations: [
//     AppComponent
//   ],
//   imports: [
//     BrowserModule,
//     AppRoutingModule,//******************************* */
//     FormsModule,
//     HttpClientModule,
//     BrowserAnimationsModule,
//     /** import ng-zorro-antd root module，you should import NgZorroAntdModule and avoid importing sub modules directly **/
//     NgZorroAntdModule
//   ],
//   bootstrap: [ AppComponent ],
//   /** config ng-zorro-antd i18n (language && date) **/
//   providers   : [
//     { provide: NZ_I18N, useValue: en_US }
//   ]
// })
// export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgZorroAntdModule, NZ_I18N, en_US } from 'ng-zorro-antd';

import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
registerLocaleData(en);


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    NgZorroAntdModule
  ],
  providers: [
    { provide: NZ_I18N, useValue: en_US }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

