using Gepdm.Log;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace Gepdm.Config
{
    
    //metodo lettura file xml di config
    public class InitSection
    {

        private InitSection() { }
        private String _String = null;
        private static InitSection _DbConn = null;
        public static string DbConn
        {
            get 
            {
                if (_DbConn == null)
                {
                    _DbConn = new InitSection { _String = InitSection.ReadXmlSysdb() };
                    return _DbConn._String;
                }
                else
                {
                    return _DbConn._String;
                }
            }
        }


        // Lettura parametri di connessione database SYSDB
        public static string ReadXmlSysdb()
        {

            string sLog = "INIZIO LETTURA PARAMETRI CONNESSIONE DATABASE";
            Logger logger = new Logger();
            logger.Log(sLog);


            XmlTextReader xtr = new XmlTextReader(@"C:\Users\user06\Desktop\Github\Gepdm\Gepdm\Gepdm\Data.xml");
            string datasource = "";
            string initialcatalog = "";
            string userid = "";
            string password = "";

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DB_Datasource")
                {
                    datasource = xtr.ReadElementString();
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DB_Catalog")
                {
                    initialcatalog = xtr.ReadElementString();
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DB_User")
                {
                    userid = xtr.ReadElementString();
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DB_Psw")
                {
                    password = xtr.ReadElementString();
                }
            }

            SqlConnectionStringBuilder sqlString = new SqlConnectionStringBuilder()
            {
                DataSource = datasource,
                InitialCatalog = initialcatalog,
                UserID = userid,
                Password = password
            };
            EntityConnectionStringBuilder entityString = new EntityConnectionStringBuilder()
            {
                Provider = "System.Data.SqlClient",
                Metadata = "res://*/Data.AlypdmModel.csdl|res://*/Data.AlypdmModel.ssdl|res://*/Data.AlypdmModel.msl",
                ProviderConnectionString = sqlString.ToString()      
            };

            sLog = "FINE LETTURA PARAMETRI CONNESSIONE DATABASE";
            logger = new Logger();
            logger.Log(sLog);

            return entityString.ConnectionString;

        }

        // Lettura parametri di connessione database gestionale
        public string ReadXmlDbges()
        {
            XmlTextReader xtr = new XmlTextReader("C:\\Users\\user06\\Desktop\\C#\\Gepdm\\Gepdm\\Data.xml");
            string sConnDb = "";

            while (xtr.Read())
            {
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DBGES_Datasource")
                {
                    sConnDb = "Data source=" + xtr.ReadElementString() + ";";
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DBGES_Catalog")
                {
                    sConnDb = sConnDb + "Initial Catalog=" + xtr.ReadElementString() + ";";
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DBGES_User")
                {
                    sConnDb = sConnDb + "User id=" + xtr.ReadElementString() + ";";
                }
                if (xtr.NodeType == XmlNodeType.Element && xtr.Name == "DBGES_Psw")
                {
                    sConnDb = sConnDb + "Password=" + xtr.ReadElementString() + ";";
                }
            }
            return sConnDb;
        }

        //public string ConnectionString()
        //{
        //    SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                
        //}

    }
}
