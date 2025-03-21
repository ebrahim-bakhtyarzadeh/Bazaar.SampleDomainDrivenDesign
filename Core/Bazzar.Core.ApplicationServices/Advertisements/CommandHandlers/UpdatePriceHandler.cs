﻿using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
	public class UpdatePriceHandler : ICommandHandler<UpdatePriceCommand>
	{
		private readonly IUnitOfWork unitOfWork;
		protected readonly IAdvertisementsRepository advertisementsRepository;

		public UpdatePriceHandler(IUnitOfWork unitOfWork, IAdvertisementsRepository advertisementsRepository)
		{
			this.unitOfWork = unitOfWork;
			this.advertisementsRepository = advertisementsRepository;
		}



		public void Handle(UpdatePriceCommand command)
		{
			var advertisement = advertisementsRepository.Load(command.Id);
			if (advertisement == null)
				throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
			advertisement.UpdatePrice(Price.FromLong(command.Price));
			unitOfWork.Commit();
		}
	}
}
