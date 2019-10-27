namespace MCB.Core.Infra.CrossCutting.Globalization.Interfaces
{
    public interface IGlobalizationManager
    {
        string GetMessage(string code, string language);
        void LoadGlobalizationMessages();
    }
}