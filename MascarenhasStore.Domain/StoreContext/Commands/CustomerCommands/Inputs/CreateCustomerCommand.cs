using FluentValidator;
using FluentValidator.Validation;
using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using MascarenhasStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs {
    public class CreateCustomerCommand : Notifiable, ICommand {
        //FailFastValidation -> fazer todas as verificacoes no banco com o minimo de consultas possiveis
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid() {
            //teste de validacao
            AddNotifications(new ValidationContract()
                 .Requires()
                 .HasMinLen(FirstName, 3, "FirstName", "O Nome deve conter pelo menos 3 caracteres")
                 .HasMaxLen(FirstName, 30, "FirstName", "O Nome deve conter no máximo 30 caracteres")
                 .HasMinLen(LastName, 3, "LastName", "O Sobrenome deve conter pelo menos 3 caracteres")
                 .HasMaxLen(LastName, 30, "LastName", "O Sobrenome deve conter no máximo 30 caracteres")
                 .IsEmail(Email, "Email", "Email inválido")
                 .HasMaxLen(Email, 80, "Email", "O Email deve conter no máximo 80 caracteres")
                 .HasLen(Document, 11, "Document", "CPF inválido")
           );

            return Valid();
        }
    }
}
