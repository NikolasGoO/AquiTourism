using AquiTourism.Core.DomainObjects;
using System;

namespace AquiTourism.Domain.Entities
{
    public class Operator : Entity
    {
        public Operator(string name, Email email, Password password, Cpf cpf)
        {
            Name = name;
            Email = email.Address;
            CPF = cpf.Number;
            PasswordSalt = password.Salt;
            PasswordHash = password.Hash;
        }

        protected Operator() { }

        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; private set; }
        public string PasswordSalt { get; private set; }
        public string CPF { get; set; }

        public void UpdatePassword(string hash, string salt)
        {
            PasswordHash = hash;
            PasswordSalt = salt;
        }
    }
}