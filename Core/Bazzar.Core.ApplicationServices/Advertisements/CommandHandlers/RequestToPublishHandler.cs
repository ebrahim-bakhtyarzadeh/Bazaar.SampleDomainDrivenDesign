using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Framework.Domain.ApplicationServices;
using System;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class RequestToPublishHandler : ICommandHandler<RequestToPublishCommand>
    {
        
        protected readonly IAdvertisementsRepository advertisementsRepository;

        public RequestToPublishHandler( IAdvertisementsRepository advertisementsRepository)
        {
            this.advertisementsRepository = advertisementsRepository;
        }
        public void Handle(RequestToPublishCommand command)
        {
            var advertisement = advertisementsRepository.Load(command.Id);
            if (advertisement == null)
                throw new InvalidOperationException($"آگهی با شناسه {command.Id} یافت نشد.");
            advertisement.RequestToPublic();
            
        }
    }
}
