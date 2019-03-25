namespace Medhurst.CodeTalk.Naming
{
    using System;
    using System.Threading.Tasks;

    public sealed class AwsS3BucketStoreDataForLater : IStoreDataForLater
    {
        private readonly AwsConfiguration awsConfiguration;

        // GOOD: works well with dependency injection
        public AwsS3BucketStoreDataForLater(AwsConfiguration awsConfiguration)
        {
            this.awsConfiguration = awsConfiguration;
        }

        public async Task WriteDataAsync(string name, byte[] contents)
        {
            // GOOD: easy to integrate as file concept will 
            // always have name and contents,
            // everything else is an implementation detail and belongs
            // in the ctor!
            await new AwsProxy(this.awsConfiguration).WriteFileAsync(name, contents);
        }
    }



    internal class AwsProxy
    {
        private AwsConfiguration awsConfiguration;

        public AwsProxy(AwsConfiguration awsConfiguration)
        {
            this.awsConfiguration = awsConfiguration;
        }

        internal Task WriteFileAsync(string name, byte[] contents)
        {
            throw new NotImplementedException();
        }
    }
}
