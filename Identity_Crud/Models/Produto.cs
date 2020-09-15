using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Crud.Models
{
    [Table("Produtos")]
    public class Produto
    {
        [Display(Name ="Codigo")]
        public int Id { get; set; }

        [Column(TypeName = "Varchar(200)")]
        public String Nome { get; set; }   
    }
}
