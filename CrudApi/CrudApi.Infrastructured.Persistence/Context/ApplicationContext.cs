using CrudApi.Core.Application.Interfaces;
using CrudApi.Core.Domain.Common;
using CrudApi.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CrudApi.Infrastructured.Persistence.Context
{
    public class ApplicationContext:DbContext
    {
        public readonly IDateTimeService _dateTime;
        public DbSet<Client> clients { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> contextOptions, IDateTimeService dateTime):base(contextOptions)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _dateTime = dateTime;

        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach(var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = _dateTime.NowUtc;
                        entry.Entity.CreatedBy = "Juan";
                    break;
                    case EntityState.Modified:
                        entry.Entity.LastModified = _dateTime.NowUtc;
                    break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
