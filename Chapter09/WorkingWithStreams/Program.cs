using System;
using static System.Console;
using System.IO;
using System.Xml;
using static System.Environment;
using static System.IO.Path;
using System.IO.Compression;

namespace WorkingWithStreams
{
    class Program
    {
        static string[] callSigns = new string[]{
            "Husker", "Starbuck", "Apollo", "Boomer",
            "Bulldog", "Athena", "Helo", "Racetrack"};
        static void Main(string[] args)
        {
            //WorkingWithText();
            WorkingWithXml();
            WorkingWithCompression();
            WorkingWithCompression(useBrotli: false);
        }

        static void WorkingWithText()
        {
            string textFile = Combine(CurrentDirectory, "streams.txt");

            StreamWriter text = File.CreateText(textFile);
            foreach (string item in callSigns)
            {
                text.WriteLine(item);
            }
            text.Close();

            WriteLine("{0} contains {1:N0} bytes", textFile, new FileInfo(textFile).Length);
            WriteLine(File.ReadAllText(textFile));
        }

        static void WorkingWithXml()
        {

            FileStream xmlFileStream = null;
            XmlWriter xml = null;
            try
            {
                string xmlFile = Combine(CurrentDirectory, "streams.xml");

                xmlFileStream = File.Create(xmlFile);

                xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings { Indent = true });

                xml.WriteStartDocument();

                xml.WriteStartElement("callsigns");

                foreach (string item in callSigns)
                {
                    xml.WriteElementString("callsign", item);
                }

                xml.WriteEndElement();

                xml.Close();
                xmlFileStream.Close();

                WriteLine("{0} contains {1:N0} bytes", xmlFile, new FileInfo(xmlFile).Length);
                WriteLine(File.ReadAllText(xmlFile));
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()} says {ex.Message}");
            }
            finally
            {
                if (xml != null)
                {
                    xml.Dispose();
                    WriteLine("The XML writer's unmanaged resources have been disposed.");
                }

                if (xmlFileStream != null)
                {
                    xmlFileStream.Dispose();
                    WriteLine("The file stream's unmanaged resources have been disposed.");
                }
            }


        }

        static void WorkingWithCompression(bool useBrotli = true)
        {
            string fileExt = useBrotli ? "brotli" : "gzip";

            string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");

            FileStream file = File.Create(filePath);

            Stream compressor;
            if (useBrotli)
            {
                compressor = new BrotliStream(file, CompressionMode.Compress);
            }
            else
            {
                compressor = new GZipStream(file, CompressionMode.Compress);
            }
            using (compressor)
            {
                using (XmlWriter xml = XmlWriter.Create(compressor))
                {
                    xml.WriteStartDocument();
                    xml.WriteStartElement("callsigns");
                    foreach (string item in callSigns)
                    {
                        xml.WriteElementString("callsign", item);
                    }
                }
            }
            WriteLine("{0} contains {1:N0} bytes", filePath, new FileInfo(filePath).Length);
            WriteLine($"The compressed contents:");
            WriteLine(File.ReadAllText(filePath));

            WriteLine("Reading the compressed XML file:");
            file = File.Open(filePath, FileMode.Open);

            Stream decompressor;
            if (useBrotli)
            {
                decompressor = new BrotliStream(file, CompressionMode.Decompress);
            }
            else
            {
                decompressor = new GZipStream(file, CompressionMode.Decompress);
            }
            using (decompressor)
            {
                using (XmlReader reader = XmlReader.Create(decompressor))
                {
                    while (reader.Read())
                    {
                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
                        {
                            reader.Read();
                            WriteLine($"{reader.Value}");
                        }
                    }
                }
            }
        }
    }
}
