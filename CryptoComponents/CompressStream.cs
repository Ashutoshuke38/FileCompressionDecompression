
using System.IO;


namespace FATCorp.CryptoComponents
{
    public class CompressStream<T> : ICompress<T> where T : new()
    {
        private void CreateDirectory(in string dirPath)
        {
            if (!Directory.Exists(dirPath) && !(dirPath == "")) // will create a dir if not present
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        protected void WriteFile(in string path, in byte[] data, in int size)
        {
            string dirPath = Path.GetDirectoryName(path);
            CreateDirectory(dirPath);
            using (FileStream fileStream = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                fileStream.Write(data, 0, size);
            }
        }

        protected void Read(in string FileName, out byte[] data)
        {
            using (Stream stream = new FileStream(FileName, FileMode.Open, FileAccess.Read))
            {
                data = new byte[stream.Length];
                stream.Read(data, 0, data.Length);
            }
        }

        protected void CompressToBytes(string FileName, ref byte[] data)
        {
            if (encryptorDecryptor.Encrypt(ref data))
            {
                WriteFile(FileName, data, data.Length);
            }
        }

        public override void Compress(in string FileName, in string compresseFile)
        {
            byte[] data;
            Read(FileName, out data);
            string currentFileName = compresseFile != "" ? compresseFile : FileName;
            CompressToBytes(currentFileName, ref data);
        }

    }

}
