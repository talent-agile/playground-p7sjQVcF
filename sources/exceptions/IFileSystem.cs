namespace Exceptions
{
    public interface IFileSystem
    {
        bool FileExists(string filePath);
        void Delete(string filePath);
        void WriteAllLines(string filePath, string contents);
    }
}