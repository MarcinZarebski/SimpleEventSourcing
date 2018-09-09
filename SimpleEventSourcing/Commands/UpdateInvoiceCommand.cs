namespace SimpleEventSourcing.Commands
{
    using System;
    using MediatR;

    public class UpdateInvoiceCommand : IRequest<Guid>
    {
        public Guid InvoiceId { get; set; }
        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }

        UpdateInvoiceCommand(string customerFullName, string customerAddress, Guid invoiceId)
        {
            CustomerFullName = customerFullName;
            CustomerAddress = customerAddress;
            InvoiceId = invoiceId;
        }
    }
}