namespace MCB.Core.Infra.CrossCutting.Security.Interfaces
{
    public interface ICryptography
    {
        byte[] Key { get; set; }
        byte[] SubKey { get; set; }

        string Decrypt(byte[] input);
        (byte[] hashByte, string hashString) Encrypt(string input);
        (byte[] hashByte, string hashString) EncryptWithHash(string input, string key = null);
    }
}