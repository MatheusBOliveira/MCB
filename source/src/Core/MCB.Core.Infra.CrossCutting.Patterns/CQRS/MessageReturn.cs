namespace MCB.Core.Infra.CrossCutting.Patterns.CQRS
{
    public abstract class MessageReturn
    {
        public bool Success { get; set; }
        public bool Continue { get; set; }

        protected MessageReturn()
        {
            Success = false;
            Continue = true;
        }

        protected MessageReturn(bool success, bool @continue)
        {
            Success = success;
            Continue = @continue;
        }
    }
}


