using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileHandler
{
    [Serializable]
    public class FileData
    {
        string _fileName;
        byte[] _data;

        public FileData(FileStream fileStream , string rootPath)
        {
            using (BinaryReader m_streamReader = new BinaryReader(fileStream))
            {
                int fileSize = (int)m_streamReader.BaseStream.Length;
                _fileName = fileStream.Name.Replace(rootPath, "");
                _data =  m_streamReader.ReadBytes(fileSize);
               
            }
        }
        public FileData(string fileName, byte[] data) { _fileName = fileName; _data = data; }
        public string FileName { get { return _fileName;} }
        public byte[] Data { get { return _data;} }
        public int Size { get { return _data.Length; } }
    }
}
