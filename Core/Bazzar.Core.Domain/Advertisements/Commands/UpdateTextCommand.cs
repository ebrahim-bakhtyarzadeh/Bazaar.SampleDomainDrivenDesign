using System;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class UpdateTextCommand
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
    }
}
