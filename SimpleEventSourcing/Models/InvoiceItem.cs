namespace SimpleEventSourcing.Models
{
    using System;

    public class InvoiceItem : AggregateRoot
    {
        public int Quantity { get; set; }

        public int Price { get; set; }
    }
}