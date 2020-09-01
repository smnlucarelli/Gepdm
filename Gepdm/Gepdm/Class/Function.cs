using Gepdm.Config;
using Gepdm.Log;
using System;
using System.Collections.Generic;
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


        public bool Elabora ()
        {
            bElabora = false;

            var opensection = new OpenSection();
            var pdm = opensection.SqlQuery();


            if (opensection.SqlConn().State == System.Data.ConnectionState.Open)
            {
                bElabora = true;
            }
            else
            {
                bElabora = false;
            }

            return bElabora;
        }


        
        

     



    }
}
