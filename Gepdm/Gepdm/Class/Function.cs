using Gepdm.Class;
using Gepdm.Config;
using Gepdm.Data;
using Gepdm.Log;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepdm
{
    public class Function
    {
        public string sLog { get; set; }
        public bool bElabora { get; set; }
        public Logger logger { get; set; }


        public void Elabora ()
        {
            //Apertura connessione EntityModel Database
            //InitSection init = new InitSection();
            //init.ReadXmlSysdb();
            AlypdmEntities pdm = new AlypdmEntities();

            sLog = "";
            logger = new Logger();
            logger.Log(sLog);

            //Query estrazione IDEXPORT PDM non ancora validati e importati
            var getidexport = new GetIdExport();
            var idexport = getidexport.QueryIdExport();


            //
            foreach (var item in idexport)
            {

                sLog = "";
                logger = new Logger();
                logger.Log(sLog);

                var getanagart = new GetAnagArt();
                var anagart = getanagart.QueryAnagArt(item);

                foreach (var art in anagart)
                {
                    if (art.CODPROV.Trim() == string.Empty || art.CODPROV.Trim() == null)
                    {
                        art.IDEXPORTVAL = 2;
                    }
                    else if (art.CODTIPOPROD.Trim() == string.Empty || art.CODTIPOPROD.Trim() == null)
                    {
                        art.IDEXPORTVAL = 2;
                    }
                    else
                    {
                        art.IDEXPORTVAL = 1;
                    }
                }

                var pdmartnval = new List<PDMT_ANAGART>(anagart
                    .Where(x => x.IDEXPORT == item.IDEXPORT && x.IDEXPORTVAL == 2))
                    .Count();

                var pdmartval = new List<PDMT_ANAGART>(anagart
                    .Where(x => x.IDEXPORT == item.IDEXPORT && x.IDEXPORTVAL == 1))
                    .Count();


                sLog = "ARTICOLI VALIDATI: " + pdmartval.ToString();
                logger = new Logger();
                logger.Log(sLog);

                sLog = "ARTICOLI NON VALIDATI: " + pdmartnval.ToString();
                logger = new Logger();
                logger.Log(sLog);

                using (var ctx = new AlypdmEntities())
                {
                    if (pdmartnval > 0)
                    {

                        var articoli = new List<PDMT_ANAGART>(ctx.PDMT_ANAGART
                            .Where(x => x.IDEXPORT == item.IDEXPORT));

                        var diba = new List<PDMT_DIBA>(ctx.PDMT_DIBA
                            .Where(x => x.IDEXPORT == item.IDEXPORT));

                        foreach (var art in articoli)
                        {
                            art.FLGVALIDATE = 2;
                        }

                        foreach (var d in diba)
                        {
                            d.FLGVALIDATE = 2;
                        }

                        sLog = "IDEXPORT " + item.IDEXPORT + " NON VALIDATO!";
                        logger = new Logger();
                        logger.Log(sLog);

                    }
                    else
                    {
                        var articoli = new List<PDMT_ANAGART>(ctx.PDMT_ANAGART
                            .Where(x => x.IDEXPORT == item.IDEXPORT));

                        var diba = new List<PDMT_DIBA>(ctx.PDMT_DIBA
                            .Where(x => x.IDEXPORT == item.IDEXPORT));


                        foreach (var art in articoli)
                        {
                            art.FLGVALIDATE = 1;
                        }

                        foreach (var d in diba)
                        {
                            d.FLGVALIDATE = 1;
                        }

                        sLog = "IDEXPORT " + item.IDEXPORT + " VALIDATO!";
                        logger = new Logger();
                        logger.Log(sLog);
                    }

                    ctx.SaveChanges();

                }



                sLog = "FINE ACQUISIZIONE ARTICOLI IDEXPORT " + item.IDEXPORT;
                logger = new Logger();
                logger.Log(sLog);

            }



        }

    }
}
