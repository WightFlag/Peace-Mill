using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Peace_Mill
{
    class ContentLoader <T>
    {        
        public Type ObjectType;

        public ContentLoader()
        {
            ObjectType = typeof(T);
        }

        public T Load(string path)
        {
            T ObjectToLoad;
            using (var sr = new StreamReader(path))
            {
                var xml = new XmlSerializer(ObjectType);
                ObjectToLoad = (T)xml.Deserialize(sr);
            }

            return ObjectToLoad;
        }

        public void Save (string path, T obj)
        {
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
            {
                using (var sw = new StreamWriter(fs))
                {
                    var xml = new XmlSerializer(ObjectType);
                    xml.Serialize(sw, obj);
                }
            }
        }
    }
}
