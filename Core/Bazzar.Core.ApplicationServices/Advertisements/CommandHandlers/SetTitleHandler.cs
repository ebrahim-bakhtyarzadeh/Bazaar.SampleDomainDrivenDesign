using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;

using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class SetTitleHandler : ICommandHandler<SetTitleCommand>
    {
        protected readonly IAdvertisementsRepository advertisementsRepository;

        public SetTitleHandler( IAdvertisementsRepository advertisementsRepository)
        {
            this.advertisementsRepository = advertisementsRepository;
        }
        public void Handle(SetTitleCommand command)
        {
            var advertisement = advertisementsRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.SetTitle(AdvertismentTitle.FromString(command.Title));
            advertisementsRepository.Add(advertisement);

      
        }
    }
}
