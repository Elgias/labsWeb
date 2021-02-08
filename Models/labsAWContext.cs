using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using labs.Models.EF_Models;
using labs.Models.EF_Models.Views;

namespace labs.Models
{
    public class labsAWContext : DbContext
    {
        public labsAWContext(DbContextOptions<labsAWContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Database.Migrate();
            Database.ExecuteSqlRaw(@"
                create or alter view ClientShortView as
                select 
                c.Id as [ClientId],
                CONCAT(c.LastName, ' ', c.FirstName) as [ClientFullName],
                CONCAT(c.LastName, ' ', c.FirstName, ', ', c.Id) as [ClientShortInfo],
                c.Email as [ClientEmail],
                c.SequentialNumber as [ClientSequentialNum]
                from Clients as c;"
            );

            Database.ExecuteSqlRaw(@"
                create OR ALTER view ClientBillView as
                select
                c.ClientFullName,
                SUM(lw.Price) as [Total],
                sum(case when o.CompleteDateTime is null then 0 else lw.Price end) as [CompletedWorksTotal],
                iif(sum(o.Payed) is null, 0, sum(o.Payed)) as [Payed]
                from 
	                ClientShortView as c, Orders as o, 
	                LaboratoryWorks as lw
                where c.ClientId = o.ClientId and o.LaboratoryWorkId = lw.Id
                group by c.ClientFullName"
            );

            Database.ExecuteSqlRaw(@"
                create or alter view LaboratoryWorksView as
                select 
                lw.Id as [LabWorkId],
                s.Id as [SubjectId],
                s.Title as [SubjectTitle],
                lw.Number as [LabWorkNum],
                lw.Price as [LabPrice],
                Concat(s.Title,' ',lw.Number) as [ShortName]
                from Subjects as s, LaboratoryWorks as lw
                where s.Id = lw.Id"
            );

            Database.ExecuteSqlRaw(@"
                create or alter view OrdersDetailedView as
                select 
                o.Id as [Id],
                cs.ClientId as [ClientId],
                cs.ClientFullName as [ClientFullName],
                lwv.LabWorkId as [LabWorkId],
                lwv.SubjectTitle as [LabWorkSubjTitle],
                lwv.LabWorkNum as [LabWorkNum],
                o.RegisterDateTime,
                o.CompleteDateTime,
                lwv.LabPrice as [Price],
                o.Discount,
                o.Payed
                from Orders as o, ClientShortView as cs, LaboratoryWorksView as lwv
                where o.ClientId = cs.ClientId and o.LaboratoryWorkId = lwv.LabWorkId"
            );
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

            modelBuilder.Entity<ShortClientViewModel>(b =>
            {
                b.HasNoKey();
                b.ToView("ClientShortView");
            });

            modelBuilder.Entity<LaboratoryWorkDetailedViewModel>(b =>
            {
                b.HasNoKey();
                b.ToView("LaboratoryWorksView");
            });

            modelBuilder.Entity<ClientBillViewModel>(b =>
            {
                b.HasNoKey();
                b.ToView("ClientBillView");
            });

            modelBuilder.Entity<OrdersDetailedViewModel>(b =>
            {
                b.HasNoKey();
                b.ToView("OrdersDetailedView");
            });
            
        }
        public DbSet<ClientModel> Clients { get; set; }
        public DbSet<LaboratoryWorkModel> LaboratoryWorks { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<ShortClientViewModel> ShortClientsView { get; set; }
        public DbSet<LaboratoryWorkDetailedViewModel> LaboratoryWorkDetailedView { get; set; }
        public DbSet<ClientBillViewModel> ClientsBillsView { get; set; }
        public DbSet<OrdersDetailedViewModel> OrdersDetailedView { get; set; }
    }
}
