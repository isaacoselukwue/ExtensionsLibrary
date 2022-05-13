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
