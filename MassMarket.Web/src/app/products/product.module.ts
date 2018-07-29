import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductRoutingModule } from './product-routing.module';
import { SearchComponent } from './search/search.component';
import {
  MatSidenavModule,
  MatIconModule,
  MatButtonModule,
  MatToolbarModule,
  MatFormFieldModule,
  MatInputModule,
  MatSelectModule,
  MatOptionModule,
  MatCardModule,
  MatProgressBarModule,
  MatSliderModule,
  MatListModule,
  MatButtonToggleModule,
  MatPaginatorModule
} from '@angular/material';
import { NouisliderModule } from 'ng2-nouislider';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ProductCardComponent } from './product-card/product-card.component';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ProductListItemComponent } from './product-list-item/product-list-item.component';

@NgModule({
  imports: [
    CommonModule,
    ProductRoutingModule,
    MatSidenavModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatOptionModule,
    HttpClientModule,
    ReactiveFormsModule,
    MatCardModule,
    FlexLayoutModule,
    MatProgressBarModule,
    MatSliderModule,
    MatListModule,
    MatButtonToggleModule,
    MatPaginatorModule,
    NouisliderModule
  ],
  declarations: [SearchComponent, ProductCardComponent, ProductListItemComponent]
})
export class ProductModule { }
