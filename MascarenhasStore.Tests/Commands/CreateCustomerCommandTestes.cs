using MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Tests.Commands {
    public class CreateCustomerCommandTestes {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid() {
            var command = new CreateCustomerCommand();

            command.FirstName = "Matheus";
            command.LastName = "Mascarenhas";
            command.Document = "32321323";
            command.Email = "mattmascarenhas@gmail.com";
            command.Phone = "1212121221";


            Assert.AreEqual(true, command.Valid());
        }
    }
}
