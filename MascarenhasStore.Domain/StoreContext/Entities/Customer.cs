using FluentValidator;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using MascarenhasStore.Shared.Entities;
using System;

namespace MascarenhasStore.Domain.StoreContext.Entities
{

    public class Customer : Entity {
        private readonly IList<Address> _addresses;
        public Customer(Name name, Document document, Email email, string phone){
            this.Name = name;
            this.Document = document;
            this.Email = email;
            this.Phone = phone;
            this._addresses = new List<Address>();
            
        }
        public Name Name { get; private set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray(); //apenas metodos de leitura

        public void AddAddress(Address address) {
            //validar o endereço
            //adicionar o endereço
            _addresses.Add(address);
        }

        public override string ToString() {
            return Name.ToString();
        }
    }
}
