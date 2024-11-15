using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml;

namespace Assignment_03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlWriterSettings settings = new
       XmlWriterSettings(); settings.Indent = true;
            settings.IndentChars = "\t";
            XmlWriter w = XmlWriter.Create("GPS.xml", settings);
            w.WriteStartDocument();
            w.WriteStartElement("GPS_Log");

            w.WriteStartElement("Position");
            w.WriteAttributeString("Datetime", DateTime.Now.ToString());
            w.WriteElementString("x", "65.8973342");
            w.WriteElementString("y", "72.3452346");
            w.WriteStartElement("SatteliteInfo");
            w.WriteElementString("Speed", "40");
            w.WriteElementString("NoSatt", "7");
            w.WriteEndElement();
            w.WriteEndElement();

            w.WriteStartElement("Image");
            w.WriteAttributeString("Resolution", "1024x800");
            w.WriteElementString("Path", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pexels.com%2Fsearch%2Fdogs%2F&psig=AOvVaw1s8Q8fk6oly2OMr6KEt4A8&ust=1731752447886000&source=images&cd=vfe&opi=89978449&ved=0CBEQjRxqFwoTCLD9q-CO3okDFQAAAAAdAAAAABAE");
            w.WriteEndDocument();
            w.Close();

            ReadAndDisplayXml();
        }

       



            static void ReadAndDisplayXml()
            {
                if (!System.IO.File.Exists("GPS.xml"))
                {
                    Console.WriteLine("GPS.xml file not found!");
                    return;
                }

                Console.WriteLine("\nReading XML file content:\n");

                using (XmlReader reader = XmlReader.Create("GPS.xml"))
                {
                    while (reader.Read())
                    {
                        switch (reader.NodeType)
                        {
                            case XmlNodeType.Element:
                                Console.WriteLine($"Element: {reader.Name}");
                                if (reader.HasAttributes)
                                {
                                    while (reader.MoveToNextAttribute())
                                    {
                                        Console.WriteLine($"\tAttribute: {reader.Name} = {reader.Value}");
                                    }
                                    reader.MoveToElement(); 
                                }
                                break;
                            case XmlNodeType.Text:
                                Console.WriteLine($"\tText: {reader.Value}");
                                break;
                            case XmlNodeType.EndElement:
                                Console.WriteLine($"End Element: {reader.Name}");
                                break;
                        }
                    }
                }
            }
    }
}
