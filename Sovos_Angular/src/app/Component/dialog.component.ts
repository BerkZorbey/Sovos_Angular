import { HttpClient } from '@angular/common/http';
import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Observable } from 'rxjs';
import { Invoice } from '../Model/invoice.model';
import { InvoiceLine } from '../Model/invoiceLine.model';

interface InvoiceId {
  id:number
}

@Component({
  selector: 'app-dialog',
  templateUrl: 'dialog.component.html',
})
export class DialogComponent implements OnInit {
  public totalPrice :number = 0;
  public InvoiceDetail!: Observable<Invoice>;
  public InvoiceModel: Invoice = {
    InvoiceHeader: undefined,
    InvoiceLine: undefined
  };

  constructor(private httpClient: HttpClient, @Inject(MAT_DIALOG_DATA) public data: InvoiceId) { }
  ngOnInit() {
    this.InvoiceDetail = this.httpClient.get<Invoice>('invoice/' + this.data.id);
    this.InvoiceDetail.forEach(x => this.InvoiceModel.InvoiceHeader = x.InvoiceHeader);
    this.InvoiceDetail.forEach(y => this.InvoiceModel.InvoiceLine = y.InvoiceLine);
    this.InvoiceDetail.forEach(z => z.InvoiceLine.forEach((item: { Quantity: number; UnitPrice: number; }) => this.totalPrice += item.Quantity * item.UnitPrice));
  }
  
  
  
}
