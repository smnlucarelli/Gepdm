using Gepdm.Config;
using Gepdm.Data;
using Gepdm.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gepdm.Class
{
    public class GetIdExport
    {
        public string sLog { get; set; }
        public Logger logger { get; set; }


        //Query estrazione IDEXPORT PDM non ancora validati e importati
        public List<PDMT_ANAGART> QueryIdExport ()
        {
            //Apertura connessione EntityModel Database
            //InitSection init = new InitSection();
            //init.ReadXmlSysdb();
            AlypdmEntities pdm = new AlypdmEntities();

            //Scrittura log di apertura
            sLog = "INIZIO LETTURA IDEXPORT DA VALIDARE";
            logger = new Logger();
            logger.Log(sLog);

            //Inizializzazione lista record da valutare da PDM
            var allidexport = new List<PDMT_ANAGART>(pdm.PDMT_ANAGART
                .Where(x => x.FLGIMPORT == 0 && x.FLGVALIDATE == 0)
                .ToList());

            var idexport = allidexport
                .GroupBy(g => new { g.IDEXPORT })
                .Select(g => g.FirstOrDefault())
                .ToList();

            foreach (var item in idexport)
            {
                sLog = "IDEXPORT DA VALIDARE: " + item.IDEXPORT;
                logger = new Logger();
                logger.Log(sLog);
            }

            //Scrittura log di chiusura
            sLog = "FINE LETTURA IDEXPORT DA VALIDARE";
            logger = new Logger();
            logger.Log(sLog);

            return idexport;
        }

        //Metodo per compilare la List<PdmIdExport>
        //private PdmIdExport AddIdExport(DataRow dr)
        //{
        //    PdmIdExport pdmidexport = new PdmIdExport();
        //    pdmidexport.IdExport = dr["Idexport"].ToString();

        //    return pdmidexport;
        //}

        //private tPdmAnagart GetPdmAnagart(DataRow dr)
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
