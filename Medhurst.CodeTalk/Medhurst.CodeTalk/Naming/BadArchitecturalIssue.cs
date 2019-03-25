using System.Globalization;
using System.Threading.Tasks;

namespace Medhurst.CodeTalk.Naming
{
    public sealed class AwsConfiguration
    {
        public string BucketName { get; set; }
        public string ApiKey { get; set; }
        public string Secret { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public int RetryCount { get; set; }
    }

    public sealed class AwsS3BucketFileWriter : IFileWriter
    {
        // BAD: path doesn't work in this implementation
        // as the concept and the implementation are all mixed up
        public async Task WriteFileAsync(string path, byte[] contents)
        {
            // 🤮 🤮 🤮 🤮 🤮  
            // BAD: because path is architectural we have to hack it
            var split = path.Split('|');
            var config = new AwsConfiguration
            {
                BucketName = split[0],
                ApiKey = split[1],
                Secret = split[2],
                FileName = split[3],
                MimeType = split[4],
                // BAD: breads Liscov Principal as FormatException
                // didn't exist before, but now possible
                RetryCount = int.Parse(split[5], CultureInfo.InvariantCulture),
            };
        }
    }
}
