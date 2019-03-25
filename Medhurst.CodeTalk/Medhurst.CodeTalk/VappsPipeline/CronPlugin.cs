namespace Medhurst.CodeTalk
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Threading.Tasks;
    using Medhurst.CodeTalk.VappsPipeline;

    public sealed class CronTaskEventArgs : EventArgs
    {
        public CronTaskEventArgs(string taskName, NameValueCollection metaData)
        {
            this.TaskName = taskName;
            MetaData = metaData;
        }

        public string TaskName { get; }
        public NameValueCollection MetaData { get; }
    }
    public interface ICronTaskManager 
    {
        event EventHandler<CronTaskEventArgs> TaskTriggered;

        Task StartTasksAsync(IEnumerable<ICronTask> tasks);
        Task ShutdownAsync();
    }

    public interface ICronTask
    {
    }

    public class CronPlugin : IPlugin, IEmitEvents
    {
        private readonly ICronTaskManager cronTaskManager;
        private readonly IEnumerable<ICronTask> tasks;

        public CronPlugin(
            ICronTaskManager cronTaskManager,
            IEnumerable<ICronTask> tasks)
        {
            this.cronTaskManager = cronTaskManager;
            this.cronTaskManager.TaskTriggered += this.TaskTriggered;
            this.tasks = tasks;
        }

        public event EventHandler<EventDetailsEventArgs> EventEmitted;

        public async Task SetupAsync()
        {
            await this.cronTaskManager.StartTasksAsync(this.tasks);
        }

        public async Task TeardownAsync()
        {
            await this.cronTaskManager.ShutdownAsync();
        }

        private void TaskTriggered(object sender, CronTaskEventArgs e)
        {
            var eventDetails = new EventDetails();

            eventDetails.Payload["TaskName"] = e.TaskName;
            eventDetails.Payload.Add(e.MetaData);

            this.EventEmitted?.Invoke(this, new EventDetailsEventArgs(eventDetails));
        }
    }
}
