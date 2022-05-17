using System.IO;

namespace PasswordManager
{
    public static class FileService
    {
        public static void SaveFile(string filePath, string fileName)
        {
            File.Copy(filePath, $"images/{fileName}", true);
        }
    }
}
