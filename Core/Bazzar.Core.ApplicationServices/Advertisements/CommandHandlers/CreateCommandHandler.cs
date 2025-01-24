﻿using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;
using Framework.Domain.Data;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
	public class CreateCommandHandler : ICommandHandler<CreateCommand>
	{

		private readonly IUnitOfWork unitOfWork;
		private readonly IAdvertisementsRepository advertisementsRepository;
		//private readonly IEventSource eventSource;

		public CreateCommandHandler(IUnitOfWork unitOfWork,
			IAdvertisementsRepository advertisementsRepository)
		{
			this.unitOfWork = unitOfWork;
			this.advertisementsRepository = advertisementsRepository;
			//this.eventSource = eventSource;
		}
		public void Handle(CreateCommand command)
		{
			if (advertisementsRepository.Exists(command.Id))
				throw new InvalidOperationException($"قبلا آگهی با شناسه {command.Id} ثبت شده است.");

			var advertisement = new Advertisment(command.Id,
				new UserId(command.OwnerId)
			);
			advertisementsRepository.Add(advertisement);
			unitOfWork.Commit();
			var events = advertisement.GetEvents();
			//eventSource.Save("Advertisement", command.Id.ToString(), events);
		}
	}
}
