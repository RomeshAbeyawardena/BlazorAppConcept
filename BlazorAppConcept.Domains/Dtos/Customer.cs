using DNI.Core.Contracts.Enumerations;
using DNI.Core.Services.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionKeyConstants = BlazorAppConcept.Domains.Constants.EncryptionKey;
namespace BlazorAppConcept.Domains.Dtos
{
    public class Customer
    {
        [Encrypt(EncryptionKeyConstants.PersonalData, EncryptionMethod.Encryption, StringCase.Upper)]
        public string FirstName { get; set; }

        [Encrypt(EncryptionKeyConstants.PersonalData, EncryptionMethod.Encryption, StringCase.Upper)]
        public string MiddleName { get; set; }

        [Encrypt(EncryptionKeyConstants.PersonalData, EncryptionMethod.Encryption, StringCase.Upper)]
        public string LastName { get; set; }

        [Encrypt(EncryptionKeyConstants.IdentificationData, EncryptionMethod.Encryption, StringCase.Upper)]
        public string EmailAddress { get; set; }

        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }
    }
}
