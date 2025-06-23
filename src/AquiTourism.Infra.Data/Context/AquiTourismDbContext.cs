using AquiTourism.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquiTourism.Infra.Data.Context
{
    public class AquiTourismDbContext : DbContext
    {
        public AquiTourismDbContext(DbContextOptions<AquiTourismDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AttractionMap());
            modelBuilder.ApplyConfiguration(new OperatorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
