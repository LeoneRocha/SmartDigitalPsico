using SmartDigitalPsico.Model.Entity.Principals;
using SmartDigitalPsico.Repository.Generic.Contracts;

namespace SmartDigitalPsico.Repository.FileManager
{
    public class RepositoryFileDisk: IRepositoryFileDisk  
    {
        public RepositoryFileDisk()
        {

        }
        public async Task<bool> Save(FileData item)
        {
            bool result = false;
            try
            {
                if (item.FileData != null)
                {
                    result = await saveFileFromByte(item);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return result;
        }

        private async Task<bool> saveFileFromByte(FileData item)
        {
            bool result = false;
            // Create random data to write to the file.
            byte[] dataArray = item.FileData;

            string folder = string.Format(@"{0}", item.FolderDestination);
            string arquivo = Path.Combine(folder, item.FileName); 

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            using (FileStream fileStream = new FileStream(string.Format(@"{0}\{1}", item.FolderDestination, item.FileName), FileMode.Create))
            {
                // Write the data to the file, byte by byte.

                await fileStream.WriteAsync(dataArray, 0, dataArray.Length);


                // Set the stream position to the beginning of the file.
                fileStream.Seek(0, SeekOrigin.Begin);

                // Read and verify the data.
                for (int i = 0; i < fileStream.Length; i++)
                {
                    if (dataArray[i] != fileStream.ReadByte())
                    {
                        throw new Exception("Error writing data.");
                    }
                }
                //throw new Exception(string.Format(@"The data was written to {0} " + "and verified.", fileStream.Name));                 
            }
            return true;
        }

        private async Task<bool> saveByteArrayToFileWithFileStream(byte[] data, string filePath)
        {
            bool result = false;
            try
            {
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }

                using var stream = File.Create(filePath);

                await stream.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return true;
        }


    }
}
