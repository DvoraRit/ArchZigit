using System;
using ZigitHub.Domain.Core.Events;

namespace ZigitHub.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

    }
}
