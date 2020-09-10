using Gepdm.Config;
using Gepdm.Data;
using Gepdm.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepdm.Class
{
    public class GetAnagArt
    {
        public string sLog { get; set; }
        public Logger logger { get; set; }

        //Query estrazione Anagrafica articoli PDM non ancora validati e importati
        public List<PDMT_ANAGART> QueryAnagArt(PDMT_ANAGART idexport)
        {
            //Apertura connessione EntityModel Database
            //InitSection init = new InitSection();
            //init.ReadXmlSysdb();
            AlypdmEntities pdm = new AlypdmEntities();

            //Scrittura log di apertura
            sLog = "INIZIO ACQUISIZIONE ARTICOLI IDEXPORT " + idexport.IDEXPORT;
            logger = new Logger();
            logger.Log(sLog);

            var pdmart = new List<PDMT_ANAGART>(pdm.PDMT_ANAGART
                .Where(x => x.IDEXPORT == idexport.IDEXPORT));

            sLog = "ARTICOLI ACQUISITI: " + pdmart.Count().ToString();
            logger = new Logger();
            logger.Log(sLog);

            return pdmart;
        }

        //private tPdmAnagart AddPdmAnagart(DataRow dr)
        //{
        //    tPdmAnagart pdmAnagart = new tPdmAnagart();
        //    pdmAnagart.Id = Convert.ToInt32(dr["Id"]);
        //    pdmAnagart.IdExport = dr["Idexport"].ToString();
        //    pdmAnagart.Codart = dr["CodArt"].ToString();
        //    pdmAnagart.Descart = dr["Descart"].ToString();
        //    pdmAnagart.Descartest = dr["Descartest"].ToString();
        //    pdmAnagart.Um1 = dr["Um1"].ToString();
        //    pdmAnagart.Codfam = dr["Codfam"].ToString();
        //    pdmAnagart.Descfam = dr["Descfam"].ToString();
        //    pdmAnagart.Codsfam = dr["Codsfam"].ToString();
        //    pdmAnagart.Descsfam = dr["Descsfam"].ToString();
        //    pdmAnagart.Codgruppo = dr["Codgruppo"].ToString();
        //    pdmAnagart.Descgruppo = dr["Descgruppo"].ToString();
        //    pdmAnagart.Codsgruppo = dr["Codsgruppo"].ToString();
        //    pdmAnagart.Descsgruppo = dr["Descsgruppo"].ToString();
        //    pdmAnagart.Codprov = dr["Codprov"].ToString();
        //    pdmAnagart.Codtipoprod = dr["Codtipoprod"].ToString();
        //    pdmAnagart.Codrep = dr["Codrep"].ToString();
        //    pdmAnagart.Userexport = dr["Userexport"].ToString();
        //    pdmAnagart.Flgimport = Convert.ToInt32(dr["Flgimport"]);
        //    pdmAnagart.Flgvalidate = Convert.ToInt32(dr["Flgvalidate"]);

        //    return pdmAnagart;
        //}


    }
}
