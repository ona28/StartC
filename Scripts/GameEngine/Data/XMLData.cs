using System.IO;
using System.Xml.Serialization;

namespace GameEngine3D
{
    public sealed class XMLData<T> : IData<T>
    {
        public void Save(T data, string path = "")
        {
            XmlSerializer xml = new XmlSerializer(data.GetType());
            FileStream f = new FileStream(path, FileMode.Create, FileAccess.Write);
            xml.Serialize(f, data);
            f.Close();
        }

        public T Load(string path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(T));
            FileStream f = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            T data = (T)xml.Deserialize(f);
            f.Close();

            return data;
        }
    }
}
