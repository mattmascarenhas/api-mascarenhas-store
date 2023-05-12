using MascarenhasStore.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Tests.ValueObjects {
    [TestClass]
    public class NameTests {
        private Name validName;
        private Name invalidName;

        public NameTests() {
            validName = new Name("Matheus", "Mascarenhas");
            invalidName = new Name("", "M");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid() {
            //(o que esperar do teste, o que esta sendo testado)
            Assert.AreEqual(false, invalidName.IsValid);
            Assert.AreEqual(2, invalidName.Notifications.Count); //espero duas notificações, pois o firstName e lastName estão inválidos

        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid() {
            //(o que esperar do teste, o que esta sendo testado)
            Assert.AreEqual(true, validName.IsValid);
            Assert.AreEqual(0, validName.Notifications.Count);
        }
    }
}
