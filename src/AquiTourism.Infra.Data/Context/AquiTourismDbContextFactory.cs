using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Infra.Data.Context
{
    public class AquiTourismDbContextFactory : IDesignTimeDbContextFactory<AquiTourismDbContext>
    {
        public AquiTourismDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AquiTourismDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-DAK4ILI\\LOCALDB;Database=AquiTourismDB;User ID=Desenvolvedor;Password=desenvolvedorAqui;TrustServerCertificate=true"); 
            return new AquiTourismDbContext(optionsBuilder.Options);
        }
    }
}
