using MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MascarenhasStore.Domain.StoreContext.Handlers;
using MascarenhasStore.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Tests.Handlers {
    public class CustomerHandlerTests {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid() {
            var command = new CreateCustomerCommand();

            command.FirstName = "Matheus";
            command.LastName = "Mascarenhas";
            command.Document = "32321323";
            command.Email = "mattmascarenhas@gmail.com";
            command.Phone = "1212121221";


            Assert.AreEqual(true, command.Valid());

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}
