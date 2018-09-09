namespace SimpleEventSourcing.Events
{
    using System;
    using MediatR;

    public class InvoiceCreatedEvent : Event, IRequest<Unit>
    {
        public string CustomerFullName { get; set; }

        public string CustomerAddress { get; set; }

        public InvoiceCreatedEvent(Guid aggregateId, string customerFullName, string customerAddress) : base(aggregateId)
        {
            CustomerFullName = customerFullName;
            CustomerAddress = customerAddress;
        }
    }
}