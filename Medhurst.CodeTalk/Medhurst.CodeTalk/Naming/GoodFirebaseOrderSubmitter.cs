namespace Medhurst.CodeTalk.Naming
{
    public sealed class FirebaseSettings
    {
        public string FunctionsBaseUrl { get; set; }
    }

    public interface ISubmitOrder
    {
    }

    // GOOD: class name defines single responsibility
    public sealed class FirebaseFunctionOrderSubmitter : ISubmitOrder
    {
        private readonly FirebaseSettings settings;
        private readonly IWebRequest http;

        // GOOD: dependencies injected into ctor
        public FirebaseFunctionOrderSubmitter(
            // GOOD: settings work well with DI
            FirebaseSettings settings,
            IWebRequest http)
        {
            this.settings = settings;
            this.http = http;
        }

        // ...
    }
}
