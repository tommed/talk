namespace Medhurst.CodeTalk.Naming
{
    using System.IO;
    using System.Threading.Tasks;

    // GOOD: high-level concept is without 'architecture'
    public interface IStoreDataForLater
    {
        Task WriteDataAsync(string name, byte[] contents);
    }

    // GOOD: name clearly documents responsibility of class
    public sealed class LocalFileStoreDataForLater : IStoreDataForLater
    {
        private readonly string parentDirectory;

        // GOOD: implementation details in ctor
        public LocalFileStoreDataForLater(string parentDirectory)
        {
            this.parentDirectory = parentDirectory;
        }

        /// <inheritdoc/>
        public async Task WriteDataAsync(string name, byte[] contents)
        {
            // GOOD: domain-specific logic using ctor parameters
            var filePath = Path.Combine(this.parentDirectory, name);
            await File.WriteAllBytesAsync(filePath, contents);
        }
    }
}

