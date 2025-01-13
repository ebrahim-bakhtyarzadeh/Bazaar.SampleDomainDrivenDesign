using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class UpdateTextHandler : ICommandHandler<UpdateTextCommand>
    {
        protected readonly IAdvertisementsRepository advertisementsRepository;

        public UpdateTextHandler(IAdvertisementsRepository advertisementsRepository)
        {
            this.advertisementsRepository = advertisementsRepository;
        }
        public void Handle(UpdateTextCommand command)
        {
            var advertisement = advertisementsRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.UpdateText(AdvertismentText.FromString(command.Text));
            advertisementsRepository.Add(advertisement);   
            
        }
    }
}
