using FATCorp.FSerializerDeserializer;
using FileHandler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FATCorp.CryptoComponents
{
    public class FilesCompressStream : CompressStream<List<FileData>>
    {
        private FileDataSerializerDeserializer _serializerDeserializer;
        public FilesCompressStream()
        {
            _serializerDeserializer = new FileDataSerializerDeserializer();
        }

        private void ReadFile(in string dir, in string rootPath)
        {
            using (FileStream fileStream = new FileStream(dir, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                Data.Add(new FileData(fileStream, rootPath));
            }
        }

        private void ReadFiles(in string[] dirs, in string rootPath)
        {
            for (int i = 0; i < dirs.Length; i++)
            {
                ReadFile(dirs[i], rootPath);
            }
        }

        public override void Compress(in string FileName, in string compressePath)
        {
            try
            {
                string[] dirs = Directory.GetFiles(compressePath, "*.*", SearchOption.AllDirectories);
                ReadFiles(dirs, compressePath);
                byte[] serializedData = _serializerDeserializer.Serialize(Data);
                CompressToBytes(FileName, ref serializedData);
            }
            catch (Exception ex)
            {
                Debug.Assert(false);
                throw ex;
            }

        }
    }
}
