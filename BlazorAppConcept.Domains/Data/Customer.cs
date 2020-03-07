using DNI.Core.Contracts.Enumerations;
using DNI.Core.Services.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionKeyConstants = BlazorAppConcept.Domains.Constants.EncryptionKey;
namespace BlazorAppConcept.Domains.Data
{
    #pragma warning disable CA1819
    public class Customer
    {
        [AutoMapper.IgnoreMap, Encrypt(EncryptionKeyConstants.PersonalData, EncryptionMethod.Encryption)]
        public byte[] FirstName { get; set; }
        [AutoMapper.IgnoreMap, Encrypt(EncryptionKeyConstants.PersonalData, EncryptionMethod.Encryption)]
        public byte[] MiddleName { get; set; }
        [AutoMapper.IgnoreMap, Encrypt(EncryptionKeyConstants.PersonalData, EncryptionMethod.Encryption)]
        public byte[] LastName { get; set; }
        [AutoMapper.IgnoreMap, Encrypt(EncryptionKeyConstants.IdentificationData, EncryptionMethod.Encryption)]
        public byte[] EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Id { get; set; }
    }
}
