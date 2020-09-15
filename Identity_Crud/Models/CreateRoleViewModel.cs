using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Identity_Crud.Models
{
    public class CreateRoleViewModel
    {
      
            [Required]
            [Display(Name = "Role")]
            public string RoleName { get; set; }
        
    }
}
