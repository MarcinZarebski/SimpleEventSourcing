namespace SimpleEventSourcing.Events
{
    using System;
    using MediatR;

    public class InvoiceItemAddedEvent : Event, IRequest<Unit>
    {
        public Guid Id;
        public int Price;
        public int Quantity;

        public InvoiceItemAddedEvent(Guid id, int price, int quantity): base(id)
        {
            Id = id;
            Price = price;
            Quantity = quantity;
        }
    }
}
