using FluentValidator;
using MascarenhasStore.Domain.StoreContext.Enum;
using MascarenhasStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs {
    public class AddAddressCommand : Notifiable, ICommand {
        public Guid IdCustomer { get; set; }
        public string Street { get; set; } 
        public string Number { get; set; } 
        public string Complement { get; set; } 
        public string District { get; set; } 
        public string City { get; set; } 
        public string State { get; set; } 
        public string Country { get; set; } 
        public string ZipCode { get; set; } 
        public EAddressType Type { get; set; }

        bool ICommand.Valid() {
            return IsValid;
        }

    }
}
