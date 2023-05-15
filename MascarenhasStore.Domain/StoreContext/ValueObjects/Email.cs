using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.ValueObjects {
    public class Email : Notifiable {
        public Email(string address) {
            Address = address;

            //teste de validacao se é email
            AddNotifications(new ValidationContract()
                 .Requires()
                 .IsEmail(Address, "Email", "Email inválido")
                 .HasMaxLen(Address, 80, "Email", "O Email deve conter no máximo 80 caracteres"));
        }

        public string Address { get; private set; }

        public override string ToString() {
            return Address;
        }
    }
}
