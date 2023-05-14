using Cafe.Model.Cafes;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe.Persistence.Mapeo
{
    public class BebidaEntityTypeConfigurations : EntityTypeConfiguration<Bebida>
    {
        public BebidaEntityTypeConfigurations() {
            ToTable("Bebida");
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);

            Property(p => p.Nombre).IsRequired().HasMaxLength(250);
            Property(p => p.Descripcion).IsRequired().HasMaxLength(250);
            Property(p => p.Precio).IsRequired();
        }
    }
}
