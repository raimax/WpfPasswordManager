using System.IO;

namespace PasswordManager
{
    public static class FileService
    {
        public static void SaveFile(string filePath, string fileName)
        {
            if (File.Exists(filePath))
            {
                File.Copy(filePath, $"images/{fileName}", true);
            }
        }
    }
}
