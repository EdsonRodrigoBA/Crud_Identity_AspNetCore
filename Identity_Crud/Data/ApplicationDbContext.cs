using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Identity_Crud.Models;

namespace Identity_Crud.Data
{
    public class ApplicationDbContext : IdentityDbContext<AplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
     
        }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<LogAuditoria> LogAuditorias { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}
