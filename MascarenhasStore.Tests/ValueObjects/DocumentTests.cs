﻿using MascarenhasStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Tests.ValueObjects {
    [TestClass]
    public class DocumentTests {
        private Document validDocument;
        private Document invalidDocument;

        public DocumentTests() {
            validDocument = new Document("06591718567");
            invalidDocument = new Document("12312312323");
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsValid() {
            //(o que esperar do teste, o que esta sendo testado)
            Assert.AreEqual(false, invalidDocument.IsValid);
            Assert.AreEqual(1, invalidDocument.Notifications.Count);

        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid() {
            //(o que esperar do teste, o que esta sendo testado)
            Assert.AreEqual(true, validDocument.IsValid);
            Assert.AreEqual(0, validDocument.Notifications.Count);
        }
    }
}
