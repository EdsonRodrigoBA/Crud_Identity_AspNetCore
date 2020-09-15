using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Crud.Models
{
    public class AplicationUser  : IdentityUser
    {
        public int ID_FUNCIONARIO { get; set; }


        // public Funcionario funcionario  { get; set; }
    }
}
