using Framework.Domain.Data;
using Framework.Domain.Entieis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bazzar.Infrastructures.Data.SqlServer
{
    public class AdvertismentUnitOfWork : IUnitOfWork
    {
        private readonly AdvertismentDbContext advertismentDbContext;

        public AdvertismentUnitOfWork(AdvertismentDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }
        public int Commit()
        {
            var entityForSave = GetEntityForSave();
            int result =  advertismentDbContext.SaveChanges();
            SaveEvents(entityForSave);
            return result;
        }

        private void SaveEvents(List<EntityEntry> entityForSave)
        {
            foreach (var item in entityForSave)
            {
                var root = item.Entity as BaseAggregateRoot<Guid>;
                if (root != null)
                {
                    var id = root.Id.ToString();
                    var aggName = item.Entity.GetType().FullName;
                }
            }
        }

        private List<EntityEntry> GetEntityForSave()
        {
            return advertismentDbContext.ChangeTracker
              .Entries()
              .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added || x.State == EntityState.Deleted)
              .ToList();
        }
    }
}
