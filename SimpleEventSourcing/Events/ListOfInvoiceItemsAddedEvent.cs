namespace SimpleEventSourcing.Events
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    using Models;

    public class ListOfInvoiceItemsAddedEvent : Event, IRequest<Guid>
    {
        public List<InvoiceItem> InvoiceItems {get; set; }

        public ListOfInvoiceItemsAddedEvent(Guid aggregateRootId, List<InvoiceItem> items) : base(aggregateRootId)
        {
            InvoiceItems = items;
        }
    }
}