namespace SimpleEventSourcing.CommandHandlers
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Commands;
    using Infrastructure;
    using MediatR;
    using Repositories;

    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Guid>
    {
        private IPublisher publisher;
        private IInvoiceRepository invoiceRepository;

        public UpdateInvoiceCommandHandler(IPublisher publisher, IInvoiceRepository invoiceRepository)
        {
            this.publisher = publisher;
            this.invoiceRepository = invoiceRepository;
        }

        public async Task<Guid> Handle(UpdateInvoiceCommand command, CancellationToken cancellationToken)
        {
            var invoice = invoiceRepository.GetById(command.InvoiceId);
            invoice.Update(command.CustomerFullName, command.CustomerAddress);

            await publisher.Publish(invoice.GetEvents());

            return invoice.Id;
        }
    }
}
