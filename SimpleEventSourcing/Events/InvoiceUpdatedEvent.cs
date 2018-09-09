namespace SimpleEventSourcing.Events
{
    using System;
    using MediatR;

    public class InvoiceUpdatedEvent : Event, IRequest<Unit>
    {
        public InvoiceUpdatedEvent(Guid id, string customerFullName, string customerAddress) : base(id)
        {
            CustomerFullName = customerFullName;
            CustomerAddress = customerAddress;
        }

        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }
    }
}
