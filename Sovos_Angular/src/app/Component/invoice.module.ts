import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AgGridModule } from 'ag-grid-angular';
import { InvoiceComponent } from './invoice.component';


@NgModule({
  declarations: [
    InvoiceComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AgGridModule
  ],
  providers: [],
  bootstrap: [InvoiceComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class InvoiceModule { }
