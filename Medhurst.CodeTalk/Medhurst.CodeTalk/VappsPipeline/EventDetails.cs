namespace Medhurst.CodeTalk.VappsPipeline
{
    using System;
    using System.Collections.Specialized;

    public class EventDetails
    {
        public EventDetails(string eventName = null, DateTimeOffset? when = null)
        {
            this.EventName = eventName;
            this.When = when.GetValueOrDefault(DateTimeOffset.Now);
            this.Payload = new NameValueCollection();
        }

        public string EventName { get; }

        public DateTimeOffset When { get; }

        public NameValueCollection Payload { get; }
    }
}
