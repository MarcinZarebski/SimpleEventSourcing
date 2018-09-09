namespace SimpleEventSourcing.Infrastructure
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Confluent.Kafka;
    using Confluent.Kafka.Serialization;
    using Events;
    using Newtonsoft.Json;

    public class Publisher : IPublisher
    {
        private Producer<string, string> producer;
        private string topic;

        public Publisher(string metadataBrokerList, string topic)
        {
            this.topic = topic;
            producer = new Producer<string, string>(
                new Dictionary<string, object>()
                {
                    {
                        "metadata.broker.list",
                        metadataBrokerList
                    }
                },
                new StringSerializer(Encoding.ASCII), new StringSerializer(Encoding.ASCII));
        }

        public async Task Publish(Event @event)
        {
            var key = @event.GetType().Name;
            var data = JsonConvert.SerializeObject(@event);

            await producer.ProduceAsync(topic, key, data);
        }

        public async Task Publish(IEnumerable<Event> events)
        {
            foreach (var e in events)
            {
                await Publish(e);
            }
        }
    }
}