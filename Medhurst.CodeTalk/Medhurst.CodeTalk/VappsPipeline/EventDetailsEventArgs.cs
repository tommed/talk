namespace Medhurst.CodeTalk.VappsPipeline
{
    using System;

    public sealed class EventDetailsEventArgs : EventArgs
    {
        public EventDetailsEventArgs(EventDetails eventDetails)
        {
            EventDetails = eventDetails;
        }

        public EventDetails EventDetails { get; }
    }
}
