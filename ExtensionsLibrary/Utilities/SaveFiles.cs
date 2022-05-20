using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionsLibrary.Utilities
{
    public class SaveFiles
    {
        public static bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
                fs.Write(byteArray);
                fs.Dispose();
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// This takes the file path and a guid for image/file Id and returns an object with the name properties, content type,
        /// byte value, response which you could return as a blob url or just the byte as you see fit.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="Imageid"></param>
        /// <returns></returns>
        public static ImageDownloadModels FileToByte(string fileName, Guid Imageid)
        {
            ImageDownloadModels response = new();
            try
            {
                if (!File.Exists(fileName))
                {
                    response.Message = "Image file does not exist";
                    response.Response = HttpStatusCode.NotFound;
                    return response;
                }
                FileExtensionContentTypeProvider provider = new();
                if (!provider.TryGetContentType(fileName, out string contentType))
                {
                    contentType = "application/octet-stream";
                }
                response.VideoEncode = File.ReadAllBytes(fileName);
                response.ContentTypes = contentType;
                response.ImageId = Imageid;
                response.FileName = Path.GetFileName(fileName);
                response.Response = HttpStatusCode.OK;
            }
            catch (Exception)
            {
                throw;
            }
            return response;
        }
        /// <summary>
        /// This method takes the file path and returns the base 64 string value of that file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string FileToBase64(string filePath)
        {
            try
            {
                byte[] response = File.ReadAllBytes(filePath);
                string image = Convert.ToBase64String(response);
                return image;
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
    

    public class VideoDownloadModels
    {
        public string ContentTypes { get; set; }
        public byte[] VideoEncode { get; set; }
        public string FileName { get; set; }
        public HttpStatusCode Response { get; set; }
        public string Message { get; set; }
    }
    public class ImageDownloadModels : VideoDownloadModels
    {
        public Guid ImageId { get; set; }
    }

}
