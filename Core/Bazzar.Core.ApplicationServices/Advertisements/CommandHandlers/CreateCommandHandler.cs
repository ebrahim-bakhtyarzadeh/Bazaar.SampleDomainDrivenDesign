using Bazzar.Core.Domain.Advertisements.Commands;
using Bazzar.Core.Domain.Advertisements.Data;
using Bazzar.Core.Domain.Advertisements.Entities;
using Bazzar.Core.Domain.Advertisements.ValueObjects;
using Framework.Domain.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers
{
    public class CreateCommandHandler : ICommandHandler<CreateCommand>
    {
        public CreateCommandHandler(IAdvertisementsRepository advertisementsRepository)
        {
            _advertisementsRepository = advertisementsRepository;
        }

        public IAdvertisementsRepository _advertisementsRepository { get; }

        public void Handle(CreateCommand command)
        {
            if (_advertisementsRepository.Exists(command.Id))
                throw new InvalidOperationException($"قبلا آگهی با شناسه {command.Id} ثبت شده است.");

            var advertisement = new Advertisment(command.Id,
                new UserId(command.OwnerId)
            );

            _advertisementsRepository.Add(advertisement);
         
        }
    }
}
