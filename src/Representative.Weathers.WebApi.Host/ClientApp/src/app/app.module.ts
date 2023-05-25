import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { StationComponent } from './station/station.component';
import { StationService } from 'src/servers/station.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    StationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: StationComponent, pathMatch: 'full' }
    ])
  ],
  providers: [StationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
