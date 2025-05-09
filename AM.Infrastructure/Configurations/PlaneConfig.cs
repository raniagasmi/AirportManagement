using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class PlaneConfig : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            //primary key annotation
            builder.HasKey(p => p.PlaneId);

            //rename table
            builder.ToTable("MyPlanes");

            //rename column
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
        }
    }
}
