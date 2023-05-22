using FluentValidator;
using FluentValidator.Validation;
using MascarenhasStore.Shared.Commands;


namespace MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs {
    public class UpdateCustomerCommand : Notifiable, ICommand {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid() {
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

            return IsValid;
        }
    }   
}
