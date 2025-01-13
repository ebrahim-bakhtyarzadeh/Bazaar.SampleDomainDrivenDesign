using System;

namespace Bazzar.Core.Domain.Advertisements.Commands
{
    public class SetTitleCommand
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
