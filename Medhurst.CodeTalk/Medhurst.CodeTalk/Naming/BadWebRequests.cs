namespace Medhurst.CodeTalk.Naming
{
    using System.Threading.Tasks;

    public interface IWebResponse { }

    public interface IWebRequest
    {
        // YAGNI: simple example doesn't include support for headers
        Task<IWebResponse> GetAsync(string url);

        Task<IWebResponse> PostAsync(string url, byte[] body);
    }

    // BAD: class name is utterly useless
    public sealed class WebRequest : IWebRequest
    {
        public Task<IWebResponse> GetAsync(string url)
        {
            // ...
        }

        public Task<IWebResponse> PostAsync(string url, byte[] body)
        {
            // ...
        }
    }
}
