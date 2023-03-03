import { Component, ViewChild} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Invoice } from '../Model/invoice.model';

@Component({
  selector: 'app-uploadFile',
  templateUrl: './uploadFile.component.html',
  styleUrls: ['./uploadFile.component.css']
})


export class UploadFileComponent {
  public data: any;

  

  public InvoiceModel: Invoice = {
    InvoiceHeader: undefined,
    InvoiceLine: undefined
  };

  constructor(private httpClient: HttpClient) {
   
  }


  postInvoice(): Observable<Invoice> {
    const headers = new HttpHeaders({ 'Content-Type': 'application/json' })
    return this.httpClient.post<Invoice>('invoice', JSON.stringify(this.data), { headers: headers });
  }

  public async uploadFile(event: any) {
    const reader = new FileReader();
    reader.onloadend = (e) => {
      this.data = reader.result?.toString();

      this.postInvoice().subscribe(
        res => {
          this.InvoiceModel.InvoiceHeader = res.InvoiceHeader;
          this.InvoiceModel.InvoiceLine = res.InvoiceLine;
        }, error => console.error(error));

    };
    reader.readAsText(event.target.files[0]);

  }


}

