using System.IO;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class StreamExtensionMethods
    {
        public static string GetString(this Stream stream)
        {
            if (stream.CanSeek)
                stream.Seek(0, SeekOrigin.Begin);

            return new StreamReader(stream).ReadToEnd();
        }
    }
}


