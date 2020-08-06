using Gepdm.Log;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Gepdm.Config
{
    public class OpenSection
    {
        public string sLog { get; set; }
        public bool bEsito { get; set; }
        public Logger logger { get; set; }

        public bool SqlConn ()
        {
            bEsito = false;

            sLog = "Inizio lettura parametri";
            logger = new Logger();
            logger.Log(sLog);

            var initsection = new InitSection();
            string sDbConn = initsection.ReadXmlDbges();

            using(SqlConnection connection = new SqlConnection(sDbConn))
            {
                connection.Open();
            }

            sLog = "Fine lettura parametri";
            logger = new Logger();
            logger.Log(sLog);




            bEsito = true;

            return bEsito;

        }
    }
}
