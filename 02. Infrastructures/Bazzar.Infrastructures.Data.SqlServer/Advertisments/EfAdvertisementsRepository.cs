using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Infrastructures.Data.SqlServer.Advertisments
{
    public class EfAdvertisementsRepository : IAdvertisementsRepository
    {
        private readonly AdvertismentDbContext advertismentDbContext;

        public EfAdvertisementsRepository(AdvertismentDbContext advertismentDbContext)
        {
            this.advertismentDbContext = advertismentDbContext;
        }


        public bool Exists(Guid id)
        {
            return advertismentDbContext.Advertisments.Any(c => c.Id == id);
        }

        public Advertisment Load(Guid id)
        {
            return advertismentDbContext.Advertisments.Find(id);
        }

        public void Add(Advertisment entity)
        {
            entity.SetTitle(new Core.Domain.Advertisements.ValueObjects.AdvertismentTitle("new title"));
            entity.UpdatePrice(new Core.Domain.Advertisements.ValueObjects.Price(new Core.Domain.Advertisements.ValueObjects.Rial(213)));
            entity.UpdateText(new Core.Domain.Advertisements.ValueObjects.AdvertismentText("fdsfs"));
            advertismentDbContext.Advertisments.Add(entity);
            advertismentDbContext.SaveChanges();
        }
    }

}
