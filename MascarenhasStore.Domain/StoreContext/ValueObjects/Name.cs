using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.ValueObjects {
    public class Name: Notifiable {
        public Name(string firstName, string lastName) {
            FirstName = firstName;
            LastName = lastName;

           //teste de validacao do tamanho do nome
           AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O Nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(FirstName, 30, "FirstName", "O Nome deve conter no máximo 30 caracteres")
                .HasMinLen(LastName, 3, "LastName", "O Sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(LastName, 30, "LastName", "O Sobrenome deve conter no máximo 30 caracteres"));
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString() {
            return $"{FirstName} {LastName}";
        }
    }
}
