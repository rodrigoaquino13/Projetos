using App_Empresas.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace App_Empresas.Models.Context
{
    public class EmpresasContext : DbContext
    {
        public DbSet <Empresas> Empresas { get; set; }
    }
}