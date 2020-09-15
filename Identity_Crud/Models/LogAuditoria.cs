using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Crud.Models
{
    [Table("LogAuditoria")]
    public class LogAuditoria
    {

        public int Id { get; set; }


        [Column(TypeName = "Varchar(200)")]
        public String Detalhes { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public String EmailUser { get; set; }
    }
}
