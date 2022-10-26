using Microsoft.AspNetCore.Http;

namespace Core.Utilities.Helpers.FileHelpers
{
    public class FileHepler : IFileHelper
    {
        /// <summary>
        /// File Delete
        /// </summary>
        /// <param name="filePath"></param>
        public void Delete(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        /// <summary>
        ///  File Update
        /// </summary>
        /// <param name="file"></param>
        /// <param name="filePath"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public string Update(IFormFile file, string filePath, string root)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);

            return Upload(file, root);
        }

        /// <summary>
        /// File Upload
        /// </summary>
        /// <param name="file"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)
            {
                if (!Directory.Exists(root))
                    Directory.CreateDirectory(root);

                string extension = Path.GetExtension(file.FileName);
                string guid = Guid.NewGuid().ToString();
                string filePath = guid + extension;

                using (FileStream fileStream = File.Create(root + filePath))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                    return filePath;
                }
            }
            return null;
        }
    }
}
