namespace MCB.Core.Infra.CrossCutting.Security.Interfaces
{
    public interface ICryptography
    {
        string Key { get; set; }

        string Decrypt(string input);
        string Encrypt(string input);
        string EncryptWithHash(string input);
    }
}