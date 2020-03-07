using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorAppConcept.Domains.Constants
{
    public static partial class EncryptionKey
    {
        public const string IdentificationData = nameof(IdentificationData);
        public const string PersonalData = nameof(PersonalData);
        public const string Default = nameof(Default);
        public const int AesKeySize = 32;
    }
}
