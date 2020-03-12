using _2doParcial_Aplicada.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2doParcial_Aplicada.Database
{
    public class Contexto : DbContext
    {
        public DbSet<LLamadas> Llamadas  { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = Database/Aplicada2doParcial");
        }
    }
}
