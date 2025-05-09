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
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            //many-to-many
            builder.HasMany(f => f.Passengers)
                .WithMany(p => p.Flights).UsingEntity(t => t.ToTable("associative_table"));
            
            //one-to-many
            builder.HasOne(f => f.Plane).WithMany(f => f.Flights)
                .HasForeignKey(f => f.PlaneFk)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
