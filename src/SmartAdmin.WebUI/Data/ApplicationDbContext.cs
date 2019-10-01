using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartAdmin.WebUI.Models;

namespace SmartAdmin.WebUI.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Almoxarifado> Almoxarifado { get; set; }
        public DbSet<CustoFlor> CustoFlor { get; set; }
        public DbSet<Flor> Flor { get; set; }
        public DbSet<TipoFlor> TipoFlor { get; set; }
    }
}
