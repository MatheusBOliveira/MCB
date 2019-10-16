using MCB.Core.Infra.CrossCutting.Queue.Interfaces;
using System.Threading.Tasks;

namespace MCB.Core.Infra.CrossCutting.Queue.Delegates
{
    public delegate Task<(bool Success, bool Redelivery)> ProcessReceivedMessageHandle(IQueue queue, IQueueConsumer consumer, string message);
}


