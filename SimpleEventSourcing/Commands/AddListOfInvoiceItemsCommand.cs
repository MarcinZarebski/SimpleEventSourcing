namespace SimpleEventSourcing.Commands
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    using Models;

    public class AddListOfInvoiceItemsCommand : IRequest<Guid>
    {
        public Guid InvoiceId { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }

        public AddListOfInvoiceItemsCommand(Guid invoiceId, List<InvoiceItem> invoiceItems)
        {
            InvoiceId = invoiceId;
            InvoiceItems = invoiceItems;
        }
    }
}
