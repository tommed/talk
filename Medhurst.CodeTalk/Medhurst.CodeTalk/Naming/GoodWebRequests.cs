namespace Medhurst.CodeTalk.Naming
{
    using System.Net.Http;
    using System.Threading.Tasks;

    public sealed class HttpResponseMessageAdapter : IWebResponse
    {
        private readonly HttpResponseMessage response;

        public HttpResponseMessageAdapter(HttpResponseMessage response)
        {
            this.response = response;
        }
    }

    // GOOD: naming of class represent 'how' (implementation detail)
    public sealed class HttpWebRequest : IWebRequest
    {
        public async Task<IWebResponse> GetAsync(string url)
        {
            using (var http = new HttpClient())
            using (var response = await http.GetAsync(url))
            {
                // GOOD: adapter pattern abstracts response object
                return new HttpResponseMessageAdapter(response);
            }
        }

        public Task<IWebResponse> PostAsync(string url, byte[] body)
        {
            // ...
        }
    }
}

