﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using MonoGame.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace RpgLibrary
{
    public static class XnaSerializer
    {
        public static void Serializer<T>(string filename, T data)
        {
            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true
            };
            using (XmlWriter writer = XmlWriter.Create(filename, settings))
            {
                IntermediateSerializer.Serialize<T>(writer, data, null);
            }
        }
        public static T Deserialize<T>(string filename)
        {
            T data;
            using(FileStream stream=new FileStream(filename, FileMode.Open))
            {
                using(XmlReader reader = XmlReader.Create(stream))
                {
                    data = IntermediateSerializer.Deserialize<T>(reader, null);
                }
            }
            return data;
        }
        
    }
}
