using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ScannerStockSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using ScannerStockSystem.Domain.Common;
using ScannerStockSystem.Domain.Common.Interfaces;

namespace ScannerStockSystem.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
          IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }


        public DbSet<Country> Countries => Set<Country>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<ContactPerson> ContactPersons => Set<ContactPerson>();
        public DbSet<ScannerType> ScannerTypes => Set<ScannerType>();
        public DbSet<Scanner> Scanners => Set<Scanner>();
        public DbSet<MasterData> MasterDatas => Set<MasterData>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Creating Country
            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Country");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).HasColumnType("nvarchar(50)").HasMaxLength(50);
                entity.Property(e => e.Description).HasColumnType("nvarchar(50)").HasMaxLength(50);
            });

            // Creating  Customer
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers"); // Set table name
                entity.HasKey(e => e.Id); // Configure primary key

                // Configure properties
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Address1).HasMaxLength(100);
                entity.Property(e => e.Address2).HasMaxLength(100);
                entity.Property(e => e.Address3).HasMaxLength(100);            

            });

            // Configure the ContactPerson entity
            modelBuilder.Entity<ContactPerson>(entity =>
            {
                entity.ToTable("ContactPersons"); // Set table name
                entity.HasKey(cp => cp.Id); // Configure primary key
                entity.HasOne(cp => cp.Customer).WithOne().HasForeignKey<Customer>(c => c.Id).OnDelete(DeleteBehavior.Cascade);
                // Configure properties
                entity.Property(cp => cp.Name).HasMaxLength(100);
                entity.Property(cp => cp.Email).HasMaxLength(100); // Adjust the max length as per your requirements

            });

            // Configure the Scanner entity
            modelBuilder.Entity<Scanner>(entity =>
            {
                entity.ToTable("Scanners");
                entity.HasKey(CP => CP.Id);
                entity.Property(cp => cp.PartNo).HasMaxLength(100);
                entity.Property(cp => cp.Make).HasMaxLength(100);
                entity.Property(cp => cp.Speed).HasMaxLength(100);
                entity.Property(cp => cp.MaxPageSize).HasMaxLength(100);
            });
            // Configure  ScannerType entity
            modelBuilder.Entity<ScannerType>(entity =>
            {
                entity.ToTable("ScannerTypes");
                entity.HasKey(CP => CP.Id);
                entity.Property(cp => cp.Type).HasMaxLength(100);
                entity.Property(cp => cp.Description).HasMaxLength(100);
            });

            // Configure  MasterDatas entity
            modelBuilder.Entity<MasterData>(entity =>
            {
                entity.ToTable("MasterDatas");
                entity.HasKey(CP => CP.Id);
                //entity.HasOne(e => e.Scanner).WithOne().HasForeignKey<Scanner>(ec=>ec.Id);
                //entity.HasOne(e => e.Customer).WithOne().HasForeignKey<Customer>(ec => ec.Id);
                entity.Property(cp => cp.ManufactureSalesOrderNo).HasMaxLength(100);
                entity.Property(cp => cp.EndCustomerPoNo).HasMaxLength(100);
                entity.Property(cp => cp.SanjePoNo).HasMaxLength(100);
                entity.Property(cp => cp.DeliveryNoteNo).HasMaxLength(100);
                entity.Property(cp => cp.DispatchDate).HasDefaultValueSql("GETDATE()"); 
                entity.Property(cp => cp.Dispatched).HasDefaultValue(false);
            });
            // Seed sample data
            modelBuilder.Entity<Country>().HasData(
                new Country { Id = 1, Name = "Country 1", Description = "Description of Country 1" },
                new Country { Id = 2, Name = "Country 2", Description = "Description of Country 2" }
            );

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<BaseEntity>()
                .Select(e => e.Entity)
                .Where(e => e.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }

        public override int SaveChanges()
        {
            return SaveChangesAsync().GetAwaiter().GetResult();
        }
    }
}
