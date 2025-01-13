using System;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class UpdatePriceCommand
    {
        public Guid Id { get; set; }
        public long Price { get; set; }
    }
}
