import { Component, TemplateRef, ViewChild} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice } from '../Model/invoice.model';
import { ColDef, GridReadyEvent } from 'ag-grid-community';
import { AgGridAngular } from 'ag-grid-angular';
import { MatDialog } from '@angular/material/dialog';
import { DialogComponent } from './dialog.component';



@Component({
  selector: 'app-invoice',
  templateUrl: './invoice.component.html',
  styleUrls: ['./invoice.component.css']
})


export class InvoiceComponent {
  public data: any;

  public columnDefs: ColDef[] = [
    { headerName:'InvoiceId', field: '_id' },
    { headerName: 'SenderTitle', field: 'InvoiceHeader.SenderTitle' },
    { headerName: 'ReceiverTitle', field: 'InvoiceHeader.ReceiverTitle' },
    { headerName: 'Date', field: 'InvoiceHeader.Date' }
  ];

  
  public defaultColDef: ColDef = {
    sortable: true,
    filter: true,
  };
  

  public InvoiceModel: Invoice = {
    InvoiceHeader: undefined,
    InvoiceLine: undefined
  };

  constructor(private httpClient: HttpClient, private dialog: MatDialog) {
   
  }

  

  public rowData$!: Observable<any[]>;

  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;

  public errorMessage: any;

  public postInvoice(): Observable<Invoice> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' })
    return this.httpClient.post<Invoice>('invoice', JSON.stringify(this.data), { headers: headers });
  }
  public onGridReady(params: GridReadyEvent) {
    this.rowData$ = this.httpClient.get<Invoice[]>('invoice');
    
  }
  openDialog() {
    this.dialog.open(DialogComponent, {
      height: '400px',
      width: '600px',
    });
  }


  
  public async uploadFile(event: any) {
    const reader = new FileReader();
    reader.onloadend = (e) => {
      this.data = reader.result?.toString();

      this.postInvoice().subscribe(
        res => {
          this.InvoiceModel.InvoiceHeader = res.InvoiceHeader;
          this.InvoiceModel.InvoiceLine = res.InvoiceLine;

        }, error => this.errorMessage = JSON.stringify(error.statusText));

    };
    reader.readAsText(event.target.files[0]);

  }


}

