using FileHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATCorp.FSerializerDeserializer
{
    internal class FileDataSerializerDeserializer : SerializerDeserializer
    {
        public byte[] Serialize(in List<FileData> fileDatas)
        {
            byte[] data;
            using (MemoryStream stream = new MemoryStream())
            {
                Serialize(stream, fileDatas);
                data = stream.ToArray();
            }
            return data;
        }

        public void Deserialize(out List<FileData> fileDatas, in byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                fileDatas = Deserialize<List<FileData>>(stream);
            }
        }


    }
}
