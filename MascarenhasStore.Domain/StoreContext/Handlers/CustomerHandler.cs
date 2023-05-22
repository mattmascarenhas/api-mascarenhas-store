using FluentValidator;
using MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.Repositories;
using MascarenhasStore.Domain.StoreContext.Services;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using MascarenhasStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Handlers {
    public class CustomerHandler:
        Notifiable,
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand> {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService) {
            _repository = repository;
            _emailService = emailService;
        }


        public ICommandResult Handle(CreateCustomerCommand command) {
            //verifica cpf
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");
            //verifica email
            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este E-mail já está em uso");
            //criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //criar a entidade
            var customer = new Customer(name, document, email, command.Phone);        //Criar a entidade

            //validar as entidades e VO
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);
            
            if (Invalid)
                return null;

            //inserir o clientee no banco
            _repository.Save(customer);

            //envia um email de boas vindas
            _emailService.Send(email.Address, "test@test.com", "titulo da mensagem", "Mensagem de boas vindas");

            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(UpdateCustomerCommand command) {
            // Busca o cliente pelo ID no repositório
            var customer = _repository.GetById(command.Id);

            // Verifica se o cliente existe
            if (customer == null) {
                AddNotification("Id", "Cliente não encontrado");
                return null;
            }

            // Verifica se o CPF já está sendo usado por outro cliente
            if (_repository.CheckDocumentForUpdate(command.Document, customer.Id))
                AddNotification("Document", "Este CPF já está em uso por outro cliente");

            // Verifica se o email já está sendo usado por outro cliente
            if (_repository.CheckEmailForUpdate(command.Email, customer.Id))
                AddNotification("Email", "Este E-mail já está em uso por outro cliente");

            // Atualiza as propriedades do cliente com base nos dados do comando
            customer.Name.Update(command.FirstName, command.LastName);
            customer.Document.Update(command.Document);
            customer.Email.Update(command.Email);
            customer.Phone = command.Phone;

            // Valida as entidades e Value Objects atualizados
            AddNotifications(customer.Name.Notifications);
            AddNotifications(customer.Document.Notifications);
            AddNotifications(customer.Email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
                return null;

            // Atualiza o cliente no banco de dados
            _repository.Update(customer);

            return new UpdateCustomerCommandResult(customer.Id, customer.Name.ToString(), customer.Email.Address);
        }


        public ICommandResult Handle(AddAddressCommand command) {
            throw new NotImplementedException();
        }
    }
}
