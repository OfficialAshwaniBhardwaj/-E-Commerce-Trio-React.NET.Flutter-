namespace FileTest.Interfaces
{
    public interface IFileService
    {
        Stream GetImageAsStream();
        byte[] GetImageAsByteArray();
    }
}
