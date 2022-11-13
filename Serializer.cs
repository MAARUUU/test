using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace testovoe
{
    public class Serializer
    {
        public static ZL__LIST ReadFromFile(string path)
        {
            var ser = new XmlSerializer(typeof(ZL__LIST));
            using var st = System.IO.File.OpenRead(path);
            ZL__LIST zl = (ZL__LIST)ser.Deserialize(st);
            return zl;
        }

    }
}
