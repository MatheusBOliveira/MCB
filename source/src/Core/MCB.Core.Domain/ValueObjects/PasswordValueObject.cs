using MCB.Core.Domain.ValueObjects.Base;
using MCB.Core.Infra.CrossCutting.Patterns.Specification.Interfaces;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace MCB.Core.Domain.ValueObjects
{
    public class PasswordValueObject
        : ValueObjectBase,
        ISelfValidator
    {
        private SecureString _securePassword;

        public PasswordValueObject()
        {
            PasswordString = string.Empty;
        }
        public PasswordValueObject(string password)
        {
            PasswordString = password;
        }

        public string PasswordString
        {
            get
            {
                var unmanagedPtr = IntPtr.Zero;
                try
                {
                    if (_securePassword == null)
                        return string.Empty;

                    unmanagedPtr = Marshal.SecureStringToGlobalAllocUnicode(_securePassword);
                    return Marshal.PtrToStringUni(unmanagedPtr);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    Marshal.ZeroFreeGlobalAllocUnicode(unmanagedPtr);
                }
            }
            set
            {
                if (_securePassword == null)
                    _securePassword = new SecureString();

                _securePassword.Clear();
                value?.ToList().ForEach(q => _securePassword.AppendChar(q));
            }
        }

        public void Validate()
        {

        }
    }
}

