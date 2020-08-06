using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gepdm.Data
{
    public class tPdmDiba
    {
        public int Id { get; set; }
        [Required]
        public string Idexport { get; set; }
        [Required]
        public string Codprog { get; set; }
        public string Codpadre { get; set; }
        [Required]
        public string Codfiglio { get; set; }
        [Required]
        public float Qta { get; set; }
        [Required]
        public string Treedepth { get; set; }
        [Required]
        public string Level { get; set; }
        [Required]
        public string  Userexport { get; set; }
        public int Flgimport { get; set; }
        public int Flgvalidate { get; set; }
    }
}
