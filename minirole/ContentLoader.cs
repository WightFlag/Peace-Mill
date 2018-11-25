using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace minirole
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

        public void Save (string path, object obj)
        {
            using (var sw = new StreamWriter(path))
            {
                var xml = new XmlSerializer(ObjectType);
                xml.Serialize(sw, obj);
            }
        }
    }
}
