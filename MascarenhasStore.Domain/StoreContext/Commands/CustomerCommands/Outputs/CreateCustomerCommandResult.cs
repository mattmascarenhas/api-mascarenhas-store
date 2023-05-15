using MascarenhasStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Outputs {
    public class CreateCustomerCommandResult: ICommandResult {
        //construtores
        public CreateCustomerCommandResult() {
        }
        public CreateCustomerCommandResult(Guid id, string name, string email) {
            Id = id;
            Name = name;
            Email = email;
        }
        //props
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

    }
}
