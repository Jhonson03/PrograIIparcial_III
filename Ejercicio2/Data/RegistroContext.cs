using Ejercicio2.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2.Data
{
    public class RegistroContext : DbContext
    {
        public DbSet<Notas> Notas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=CC1PC15-16;Database=Registro;Trusted_Connection=SSPI;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        }
    }
}
