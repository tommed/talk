namespace Medhurst.CodeTalk.Naming
{
    using System.IO;
    using System.Threading.Tasks;

    // BAD: narrow-minded name assumes will always write to a file
    public interface IFileWriter
    {
        // BAD: :path is not part of concept
        Task WriteFileAsync(string path, byte[] contents);
    }

    // BAD: naming of class does not show single reponsibility
    public sealed class FileWriter : IFileWriter
    {
        public async Task WriteFileAsync(string path, byte[] contents)
        {
            await File.WriteAllBytesAsync(path, contents);
        }
    }
}
