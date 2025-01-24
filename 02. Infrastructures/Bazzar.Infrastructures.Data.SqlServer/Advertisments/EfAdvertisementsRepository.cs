using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;

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
			advertismentDbContext.Advertisments.Add(entity);
			advertismentDbContext.SaveChanges();
		}
	}

}
