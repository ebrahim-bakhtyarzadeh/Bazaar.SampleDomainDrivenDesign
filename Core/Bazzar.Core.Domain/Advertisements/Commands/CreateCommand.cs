using System;
using System.Collections.Generic;
using System.Text;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class CreateCommand
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
    }
}
