import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatTableModule } from '@angular/material/table';
import { HttpClientModule } from '@angular/common/http';
import { AppComponent } from './app.component';
import { StatisticsComponent } from './components/statistics/statistics.component';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [AppComponent, StatisticsComponent],
  imports: [BrowserModule, MatTableModule, HttpClientModule, MatCardModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
