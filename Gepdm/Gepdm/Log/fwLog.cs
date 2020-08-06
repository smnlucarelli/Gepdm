using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Gepdm.Log
{


    public abstract class LogBase
    {
        public abstract void Log(string Message);
    }

    public class Logger : LogBase
    {
        public String CurrentDirectory { get; set; }
        public String FileName { get; set; }
        public String FilePath { get; set; }

        public Logger()
        {
            this.CurrentDirectory = Directory.GetCurrentDirectory();
            this.FileName = "Log.txt";
            this.FilePath = this.CurrentDirectory + "/" + this.FileName;
        }

        public override void Log(string Message)
        {

            System.Console.WriteLine("Logged : {0}", Message);

            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
            {
                w.Write("Log Entry | ");
                w.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), Message);
            }
        }
    }


    public class fwLog 
    {
        public string TsWhere { get; set; }
        public int TiNumeroFile { get; set; }
        public string TsValore { get; set; }

        public int TiAttivo { get; set; }

        public bool writeLog { get; set; }

           


        //public bool WriteLog (string sValore, TextWriter w)
        //{
        //    writeLog = false;


            


        //    string dFile = @"C:\Users\user06\Desktop\C#\Gepdm\Gepdm\Log.txt";

        //    if (!File.Exists(dFile))
        //    {
        //        File.Create(dFile);
        //    }


        //    w.Write($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
        //    w.Write($" :{sValore}");



        //    return writeLog;
            
        //}




    }
}
