import { InvoiceHeader } from './invoiceHeader.model';
import { InvoiceLine } from './invoiceLine.model';

export class Invoice {
  InvoiceHeader: any;
    InvoiceLine: any;
  constructor(
    InvoiceHeader: InvoiceHeader,
    InvoiceLine: InvoiceLine[] 
  ) { }
}
