namespace SimpleEventSourcing.Commands
{
    using System;
    using MediatR;

    public class CreateInvoiceCommand : IRequest<Guid>
    {
        public string CustomerFullName { get; set; }
        public string CustomerAddress { get; set; }

        public CreateInvoiceCommand(string customerFullName, string customerAddress)
        {
            CustomerFullName = customerFullName;
            CustomerAddress = customerAddress;
        }
    }
}