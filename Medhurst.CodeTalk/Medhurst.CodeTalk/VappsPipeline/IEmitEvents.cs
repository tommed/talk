namespace Medhurst.CodeTalk.VappsPipeline
{
    using System;
    using System.Threading.Tasks;

    // GOOD: little/no architecture in concept
    public interface IPlugin
    {
        Task SetupAsync();

        Task TeardownAsync();
    }

    // GOOD: interface segregation
    public interface IEmitEvents
    {
        event EventHandler<EventDetailsEventArgs> EventEmitted;
    }

    // GOOD: plug-ins are super easy to test
    public interface IReceiveEvents
    {
        Task ReceiveEventAsync(EventDetails eventDetails);
    }
}
