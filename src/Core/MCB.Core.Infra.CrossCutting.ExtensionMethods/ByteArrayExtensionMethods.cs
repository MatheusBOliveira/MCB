using System.Collections;
using System.Collections.Generic;

namespace MCB.Core.Infra.CrossCutting.ExtensionMethods
{
    public static class ByteArrayExtensionMethods
    {
        public static bool IsGreaterThan(this byte[] obj, byte[] byteArray)
        {
            return ((IStructuralComparable)obj).CompareTo(byteArray, Comparer<byte>.Default) > 0;
        }
        public static bool IsLowerThan(this byte[] obj, byte[] byteArray)
        {
            return ((IStructuralComparable)obj).CompareTo(byteArray, Comparer<byte>.Default) < 0;
        }
        public static string GetString(this byte[] obj)
        {
            return System.Text.Encoding.Default.GetString(obj);
        }
    }
}


