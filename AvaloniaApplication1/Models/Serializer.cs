using System;
using System.IO;
using System.Runtime.Serialization;
using System.Xml;

public class Serializer
{
    public void SerializeToXmlStream(object obj, Stream stream)
    {
        DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
        serializer.WriteObject(stream, obj);
    }

    public T DeserializeToXmlStream<T>(Stream stream)
    {
        DataContractSerializer serializer = new DataContractSerializer(typeof(T));
        return (T)serializer.ReadObject(stream);
    }
    
    public static byte[] SerializeToXmlBytes(object obj)
    {
        using (MemoryStream stream = new MemoryStream())
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            serializer.WriteObject(stream, obj);
            return stream.ToArray();
        }
    }

    public static object DeserializeFromXmlBytes(byte[] data, Type type)
    {
        using (MemoryStream stream = new MemoryStream(data))
        {
            DataContractSerializer serializer = new DataContractSerializer(type);
            return serializer.ReadObject(stream);
        }
    }

    public static string SerializeToXmlString(object obj)
    {
        using (StringWriter writer = new StringWriter())
        {
            DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
            using (XmlWriter xmlWriter = XmlWriter.Create(writer))
            {
                serializer.WriteObject(xmlWriter, obj);
            }
            return writer.ToString();
        }
    }

    public static object DeserializeFromXmlString(string xml, Type type)
    {
        using (StringReader reader = new StringReader(xml))
        {
            using (XmlReader xmlReader = XmlReader.Create(reader))
            {
                DataContractSerializer serializer = new DataContractSerializer(type);
                return serializer.ReadObject(xmlReader);
            }
        }
    }
}