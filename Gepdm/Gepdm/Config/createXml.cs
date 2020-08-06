using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace Gepdm.Config
{
    public class createXml
    {
        public void createFile()
        {
            XmlTextWriter xmlwriter = new XmlTextWriter("config.xml", System.Text.Encoding.UTF8);
            xmlwriter.WriteStartDocument(true);
            xmlwriter.Formatting = Formatting.Indented;
            xmlwriter.Indentation = 2;
            xmlwriter.WriteStartElement("Config");
            createNodo("NB06", "Produzione", "sa", "9999", xmlwriter);
            xmlwriter.WriteEndElement();
            xmlwriter.WriteEndDocument();
            xmlwriter.Close();
            MessageBox.Show("File XML creato!");
        }

        public void createNodo(string datasource, string catalog, string user, string psw, XmlTextWriter writer)
        {
            writer.WriteStartElement("DB");
            writer.WriteStartElement("DB_DATASOURCE");
            writer.WriteString(datasource);
            writer.WriteEndElement();
            writer.WriteStartElement("DB_CATALOG");
            writer.WriteString(catalog);
            writer.WriteEndElement();
            writer.WriteStartElement("DB_USER");
            writer.WriteString(user);
            writer.WriteStartElement("DB_PSW");
            writer.WriteString(psw);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }

    }
}
