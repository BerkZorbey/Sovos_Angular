import { HttpClientModule } from '@angular/common/http';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AgGridModule } from 'ag-grid-angular';
import { InvoiceComponent } from './invoice.component';
import { MatDialogModule} from '@angular/material/dialog';
import { DialogComponent } from './dialog.component';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";


@NgModule({
  declarations: [
    InvoiceComponent, DialogComponent
  ],
  imports: [
    BrowserModule, HttpClientModule, AgGridModule, MatDialogModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [InvoiceComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class InvoiceModule { }
