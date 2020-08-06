using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Gepdm.Config;
using Gepdm.Log;

namespace Gepdm
{
    public class Program
    {
        static void Main(string[] args)
        {
            string sLog = "INIZIO ELABORAZIONE";
            Logger logger = new Logger();
            ConsoleImport consoleImport = new ConsoleImport();
            consoleImport.
            logger.Log(sLog);

            var fn = new Function();
            bool bElabora = fn.Elabora();
            
            if (bElabora)
            {
                sLog = "FINE ELABORAZIONE TERMINATA CON SUCCESSO";
                logger = new Logger();
                logger.Log(sLog);

            }
            else
            {
                sLog = "FINE ELABORAZIONE NON TERMINATA CON SUCCESSO - ERRORE";
                logger = new Logger();
                logger.Log(sLog);
            }

        }



    }
}
