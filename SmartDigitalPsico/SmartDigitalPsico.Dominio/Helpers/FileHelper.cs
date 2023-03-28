using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;


namespace SmartDigitalPsico.Domains.Helpers
{
    public class FileHelper
    {

        public static async Task<string> GetFileFormDataUpload(IFormFile file)
        {
            using (var sr = new StreamReader(file.OpenReadStream()))
            {
                var content = await sr.ReadToEndAsync();
                //return Ok(content);
                return content;
            }
            return string.Empty;
        }


        public static async Task<string> GetFileByRequest(HttpRequest request, string folderNameDestination)
        {
            var file = request.Form.Files[0];
            ///var folderName = Path.Combine("ResourcesTemp", "FilesUpaload");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderNameDestination);
            if (file.Length > 0)
            {
                var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                var fullPath = Path.Combine(pathToSave, fileName);
                var dbPath = Path.Combine(folderNameDestination, fileName);

                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                //return Ok(new { dbPath });
                return dbPath;

            }
            else
            {
                //return BadRequest();
            }
            return string.Empty;
        }


        private static async Task<string> GetFileFromBase64String(string dataStringBase64)
        {
            if (!string.IsNullOrEmpty(dataStringBase64) && dataStringBase64?.Length > 0)
            {
                var bytes = Convert.FromBase64String(dataStringBase64);
                var decodedString = Encoding.UTF8.GetString(bytes);

                return decodedString;
            }
            return string.Empty;
            //return Ok(decodedString);
        }

        public static async void GetFromByteSaveTemp(byte[] filedata, string fileName)
        {
            if (filedata != null)
            {
                var content = new System.IO.MemoryStream(filedata);

                //MUDAR PARA BAIXAR NO NAVEGADOR ou retornar url ou retornar o bytes **QUANDO TIVER FAZENDO O FRONT
                var path = Path.Combine(Directory.GetCurrentDirectory(), "ResourcesTemp", fileName);

                await copyStream(content, path);
            }
        }

        private static async Task copyStream(MemoryStream stream, string downloadPath)
        {
            using (var fileStream = new FileStream(downloadPath, FileMode.Create, FileAccess.Write))
            {
                await stream.CopyToAsync(fileStream);
            }
        }
        public static async Task< byte[]> GetByteDataFromIFormFile(IFormFile fileData)
        {
            byte[] fileDataResult;

            using (var stream = new MemoryStream())
            {
                await fileData.CopyToAsync(stream);
                fileDataResult = stream.ToArray();
            }
            return fileDataResult;
        }
    }
}
