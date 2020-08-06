using Gepdm.Data;
using Gepdm.Log;
using System;
using System.Collections.Generic;
using System.Data;
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

        public SqlConnection SqlConn ()
        {
            bEsito = false;

            sLog = "Inizio lettura parametri";
            logger = new Logger();
            logger.Log(sLog);

            var initsection = new InitSection();
            string sDbConn = initsection.ReadXmlSysdb();

            SqlConnection connection = new SqlConnection(sDbConn);
            connection.Open();
            
            sLog = "Fine lettura parametri";
            logger = new Logger();
            logger.Log(sLog);

            bEsito = true;

            return connection;
        }

        public List<tPdmAnagart> SqlQuery ()
        {
            List<tPdmAnagart> pdmart = null;
            DataTable dt = null;

            string sQry = "SELECT *" +
                          "FROM [PDMT_ANAGART]" +
                          "WHERE [FLGIMPORT] = 0 AND [FLGVALIDATE] = 0";

            SqlConnection connection = SqlConn();
            SqlCommand command = new SqlCommand(sQry, connection);
            
            command.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(command);
            dt = new DataTable();
            da.Fill(dt);

            if (dt != null)
            {
                pdmart = new List<tPdmAnagart>();
                foreach (DataRow dr in dt.Rows)
                {
                    pdmart.Add(GetPdmAnagart(dr));
                }
            }

            return pdmart;
            
        }

        private tPdmAnagart GetPdmAnagart(DataRow dr)
        {
            tPdmAnagart pdmAnagart = new tPdmAnagart();
            pdmAnagart.Id = Convert.ToInt32(dr["Id"]);
            pdmAnagart.IdExport = dr["Idexport"].ToString();
            pdmAnagart.Codart = dr["CodArt"].ToString();
            pdmAnagart.Descart = dr["Descart"].ToString();
            pdmAnagart.Descartest = dr["Descartest"].ToString();
            pdmAnagart.Um1 = dr["Um1"].ToString();
            pdmAnagart.Codfam = dr["Codfam"].ToString();
            pdmAnagart.Descfam = dr["Descfam"].ToString();
            pdmAnagart.Codsfam = dr["Codsfam"].ToString();
            pdmAnagart.Descsfam = dr["Descsfam"].ToString();
            pdmAnagart.Codgruppo = dr["Codgruppo"].ToString();
            pdmAnagart.Descgruppo = dr["Descgruppo"].ToString();
            pdmAnagart.Codsgruppo = dr["Codsgruppo"].ToString();
            pdmAnagart.Descsgruppo = dr["Descsgruppo"].ToString();
            pdmAnagart.Codprov = dr["Codprov"].ToString();
            pdmAnagart.Codtipoprod = dr["Codtipoprod"].ToString();
            pdmAnagart.Codrep = dr["Codrep"].ToString();
            pdmAnagart.Userexport = dr["Userexport"].ToString();
            pdmAnagart.Flgimport = Convert.ToInt32(dr["Flgimport"]);
            pdmAnagart.Flgvalidate = Convert.ToInt32(dr["Flgvalidate"]);

            return pdmAnagart;
        }

    }
}
