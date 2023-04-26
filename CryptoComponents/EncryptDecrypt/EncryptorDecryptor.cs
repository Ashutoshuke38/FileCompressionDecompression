using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FATCorp.CryptoComponents.EncryptDecrypt
{
    public class EncryptorDecryptor
    {
        public bool Encrypt(ref byte[] data)
        {
            bool flag = false;
            using (MemoryStream stream = new MemoryStream())
            {
                using (DeflateStream deflate = new DeflateStream(stream, CompressionMode.Compress, leaveOpen: true))
                {
                    deflate.Write(data, 0, data.Length);
                    flag = true;
                }
                data = stream.ToArray();

            }
            return flag;
        }

        public bool Decrypt(ref byte[] data)
        {
            bool flag = false;
            using (MemoryStream stream = new MemoryStream(data))
            {
                using (MemoryStream streamOut = new MemoryStream())
                {
                    using (DeflateStream deflate = new DeflateStream(stream, CompressionMode.Decompress))
                    {
                        deflate.CopyTo(streamOut);
                        flag = true;
                    }
                    data = streamOut.ToArray();
                }
            }
            return flag;
        }
    }
}
