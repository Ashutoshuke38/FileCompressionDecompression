using FileHandler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace FATCorp
{
    namespace FSerializerDeserializer
    {
        internal class SerializerDeserializer   
        {
            private BinaryFormatter formatter;
            public SerializerDeserializer()
            {
                formatter = new BinaryFormatter();
            }

            public void Serialize(in Stream stream, object data)
            {
                formatter.Serialize(stream, data);
            }


            public T Deserialize<T>(Stream stream)
            {
                return (T)formatter.Deserialize(stream);
            }

        }
    }
    
}
