namespace MCB.Core.Infra.CrossCutting.Gateway.Models
{
    public class QueueDestination
        : Destination
    {
        public QueueDestination()
        {
            DestinationType = Enums.DestinationTypeEnum.Queue;
        }
    }
}


