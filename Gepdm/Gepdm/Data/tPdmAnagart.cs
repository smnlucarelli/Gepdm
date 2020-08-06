using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Gepdm.Data
{
    public class tPdmAnagart
    {
        public int Id { get; set; }      
        [Required]
        public string IdExport { get; set; }       
        [Required]
        public string Codart { get; set; }       
        [Required]
        public string Descart { get; set; }
        public string Descartest { get; set; }       
        [Required]
        public string Um1 { get; set; }
        public string Codfam { get; set; }
        public string Descfam { get; set; }
        public string Codsfam { get; set; }
        public string Descsfam { get; set; }
        public string Codgruppo { get; set; }
        public string Descgruppo { get; set; }
        public string Codsgruppo { get; set; }
        public string Descsgruppo { get; set; }
        [Required]
        public string Codprov { get; set; }
        [Required]
        public string Codtipoprod { get; set; }
        public string Codrep { get; set; }
        [Required]
        public string Userexport { get; set; }      
        public int Flgimport { get; set; }
        public int Flgvalidate { get; set; }
    }
}
