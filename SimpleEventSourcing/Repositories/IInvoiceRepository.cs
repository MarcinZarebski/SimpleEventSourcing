namespace SimpleEventSourcing.Repositories
{
    using System;
    using System.Collections.Generic;
    using Models;

    public interface IInvoiceRepository
    {
        void Add(Invoice invoice);
        Invoice GetById(Guid id);
        void Update(Invoice invoice);
        void UpdateItems(List<InvoiceItem> invoiceItems);
    }
}