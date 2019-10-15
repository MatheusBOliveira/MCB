namespace MCB.Core.Infra.CrossCutting.Bus.ReturnObjects
{
    public abstract class MessageReturn
    {
        public bool Success { get; set; }
        public bool Continue { get; set; }

        public MessageReturn()
        {

        }

        public MessageReturn(bool success, bool @continue)
        {
            Success = success;
            Continue = @continue;
        }
    }
}


