using MCB.Core.Infra.CrossCutting.Patterns.Adapter.Interfaces;
using MCB.Core.Infra.CrossCutting.Patterns.Specification;
using System;

namespace MCB.Core.Infra.CrossCutting.Patterns.CommunicationProtocol.Adapters
{
    public class MessageAdapter
        : IAdapter<Message, ValidationError>
    {
        public Message Adapt(Message target, ValidationError source)
        {
            if (source == null)
                return target;

            target.Type = Enums.MessageTypeEnum.Error;
            target.Code = source.Code;
            target.Description = source.Code;

            return target;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}


