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
        public string FileName { get; set; }
        public string FilePath { get; set; }
    
        public Logger()
        {
            var year = DateTime.Now.Year.ToString();
            var month = DateTime.Now.Month;
            string monthRif = "";
            var day = DateTime.Now.Day;
            string dayRif = "";

            if (month <= 9)
            {
                switch (month)
                {
                    case 1:
                        monthRif = "01";
                        break;
                    case 2:
                        monthRif = "02";
                        break;
                    case 3:
                        monthRif = "03";
                        break;
                    case 4:
                        monthRif = "04";
                        break;
                    case 5:
                        monthRif = "05";
                        break;
                    case 6:
                        monthRif = "06";
                        break;
                    case 7:
                        monthRif = "07";
                        break;
                    case 8:
                        monthRif = "08";
                        break;
                    case 9:
                        monthRif = "09";
                        break;
                }

            }

            if (day <= 9)
            {
                switch (day)
                {
                    case 1:
                        dayRif = "01";
                        break;
                    case 2:
                        dayRif = "02";
                        break;
                    case 3:
                        dayRif = "03";
                        break;
                    case 4:
                        dayRif = "04";
                        break;
                    case 5:
                        dayRif = "05";
                        break;
                    case 6:
                        dayRif = "06";
                        break;
                    case 7:
                        dayRif = "07";
                        break;
                    case 8:
                        dayRif = "08";
                        break;
                    case 9:
                        dayRif = "09";
                        break;
                }

            }

            //this.CurrentDirectory = Directory.
            this.FileName = "Log" + year + monthRif + dayRif + ".txt";
            this.FilePath = @"C:\Users\user06\Desktop\" + this.FileName;
        }

        public override void Log(string Message)
        {

            //System.Console.WriteLine("Logged : {0}", Message);

            using (System.IO.StreamWriter w = System.IO.File.AppendText(this.FilePath))
            {
                w.Write("Log | ");
                w.WriteLine("{0} {1}: {2}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString(), Message);
            }
        }
    }

    //public class fwLog 
    //{
    //    public string TsWhere { get; set; }
    //    public int TiNumeroFile { get; set; }
    //    public string TsValore { get; set; }

    //    public int TiAttivo { get; set; }

    //    public bool writeLog { get; set; }

           


    //    //public bool WriteLog (string sValore, TextWriter w)
    //    //{
    //    //    writeLog = false;


            


    //    //    string dFile = @"C:\Users\user06\Desktop\C#\Gepdm\Gepdm\Log.txt";

    //    //    if (!File.Exists(dFile))
    //    //    {
    //    //        File.Create(dFile);
    //    //    }


    //    //    w.Write($"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}");
    //    //    w.Write($" :{sValore}");



    //    //    return writeLog;
            
    //    //}




    //}
}
