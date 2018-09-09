namespace SimpleEventSourcing.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Infrastructure;
    using MediatR;
    using Models;

    public class CreateInvoiceCommandHandler : IRequestHandler<CreateInvoiceCommand, Guid>
    {
        private IPublisher publisher;

        public CreateInvoiceCommandHandler(IPublisher publisher)
        {
            this.publisher = publisher;
        }

        public async Task<Guid> Handle(CreateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = new Invoice(command.CustomerFullName, command.CustomerAddress);

            await publisher.Publish(invoice.GetEvents());

            return invoice.Id;
        }
    }
}