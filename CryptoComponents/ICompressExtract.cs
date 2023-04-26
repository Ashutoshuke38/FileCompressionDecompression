
using System;
using FATCorp.CryptoComponents.EncryptDecrypt;

namespace FATCorp.CryptoComponents
{
    public abstract class ICompressExtract<T> where T: new()
    {
        protected EncryptorDecryptor encryptorDecryptor;
        private T _Data;
        protected ref T Data => ref _Data;
        protected ICompressExtract() { _Data = new T(); encryptorDecryptor = new EncryptorDecryptor(); }
        public virtual void Compress(in string FileName, in string compressePath) { throw new NotImplementedException(); }
        public virtual void Extract(in string FileName, in string extractPath) { throw new NotImplementedException(); }
    }

    public abstract class ICompress<T> : ICompressExtract<T> where T : new()
    {
        public override abstract void Compress(in string FileName, in string compressePath);
    }
    
    public abstract class IExtract<T> : ICompressExtract<T> where T : new()
    {
        public override abstract void Extract(in string FileName, in string compressePath);
    }

   

}
