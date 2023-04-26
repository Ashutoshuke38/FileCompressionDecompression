using FATCorp.FSerializerDeserializer;
using FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FATCorp.CryptoComponents
{
    public class FilesExtractStream : CompressStream<List<FileData>>
    {
        private FileDataSerializerDeserializer _serializerDeserializer;
        public FilesExtractStream()
        {
            _serializerDeserializer = new FileDataSerializerDeserializer();
        }
        private void ExtractFiles(in string exPath)
        {
            for (int i = 0; i < Data.Count; i++)
            {
                string path = exPath + Data[i].FileName;
                FileData fileData = Data[i];
                WriteFile(path, fileData.Data, fileData.Size);
            }
        }

        public override void Extract(in string FileName, in string extractPath)
        {
            try
            {
                byte[] compData;
                Read(FileName, out compData);
                if (encryptorDecryptor.Decrypt(ref compData))
                {
                    _serializerDeserializer.Deserialize(out Data, compData);
                    ExtractFiles(extractPath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
