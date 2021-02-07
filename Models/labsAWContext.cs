using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using labs.Models.EF_Models;

namespace labs.Models
{
    public class labsAWContext : DbContext
    {
        public labsAWContext(DbContextOptions<labsAWContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderModel>(o =>
            {
                o.HasOne(i => i.LaboratoryWorkModel)
                .WithMany(i => i.Orders)
                .HasForeignKey(i => i.LaboratoryWorkId);

                o.HasOne(i => i.ClientModel)
                .WithMany(i => i.Orders)
                .HasForeignKey(i => i.ClientId);
            });

            modelBuilder.Entity<LaboratoryWorkModel>(b =>
            {
                b.HasOne(i => i.SubjectModel)
                .WithMany(i => i.LaboratoryWorkModel)
                .HasForeignKey(i => i.SubjectId);
            });
        }
    }
}
