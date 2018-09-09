namespace SimpleEventSourcing.Commands
{
    using System;
    using MediatR;

    public class AddInvoiceItemCommand : IRequest<Guid>
    {
        public Guid InvoiceId { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        AddInvoiceItemCommand(Guid invoiceId, int quantity, int price)
        {
            InvoiceId = invoiceId;
            Quantity = quantity;
            Price = price;
        }
    }
}
