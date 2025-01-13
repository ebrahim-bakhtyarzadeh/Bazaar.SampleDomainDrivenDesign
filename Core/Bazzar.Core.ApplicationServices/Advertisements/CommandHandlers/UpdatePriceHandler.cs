using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class UpdatePriceHandler : ICommandHandler<UpdatePriceCommand>
    {
        protected readonly IAdvertisementsRepository advertisementsRepository;

        public UpdatePriceHandler(IAdvertisementsRepository advertisementsRepository)
        {
            this.advertisementsRepository = advertisementsRepository;
        }



        public void Handle(UpdatePriceCommand command)
        {
            var advertisement = advertisementsRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.UpdatePrice(Price.FromLong(command.Price));

            advertisementsRepository.Add(advertisement);
        }
    }
}
