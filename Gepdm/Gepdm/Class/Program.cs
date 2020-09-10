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
            string sLog = "----------------------------------------------------------";
            Logger logger = new Logger();
            logger.Log(sLog);

            sLog = "INIZIO ELABORAZIONE";
            logger = new Logger();
            logger.Log(sLog);

            sLog = "";
            logger = new Logger();
            logger.Log(sLog);

            var fn = new Function();
            fn.Elabora();

            sLog = "";
            logger = new Logger();
            logger.Log(sLog);

            sLog = "FINE ELABORAZIONE";
            logger = new Logger();
            logger.Log(sLog);

            sLog = "----------------------------------------------------------";
            logger = new Logger();
            logger.Log(sLog);

        }



    }
}
