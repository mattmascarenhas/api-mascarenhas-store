using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.Enum;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Tests.Entities {
    [TestClass]
    public class OrderTests {

        private Customer _customer;
        private Order _order;

        private Product _mouse;
        private Product _Keyboard;
        private Product _monitor;

        public OrderTests() {
            var name = new Name("Matheus", "Mascarenhas");
            var document = new Document("06591718567");
            var email = new Email("mattmascarenhaas7@gmail.com");
            _customer = new Customer(name, document, email, "75991105310");

            _order = new Order(_customer);

            _monitor = new Product("Monitor", "Monitor gamer", "image.png", 100m, 10);
            _mouse = new Product("Mouse", "Mouse Gamer", "image.png", 100m, 10);
            _Keyboard = new Product("Teclado", "Teclado mecanico", "image.png", 100m, 10);

        }
        // verificar se consigo criar o pedido, verifica se é válido
        [TestMethod]
        public void ShouldCreateOrderWhenValid() {
            Assert.AreEqual(true, _order.IsValid);
        }

        // ao criar o pedido, o status deve ser created
        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated() {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // ao adicionar o um novo item, a quantidade de itens deve mudar 
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems() {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);

            Assert.AreEqual(2, _order.Items.Count);
        }

        // ao adicionar um novo item, deve subtrair a quantidade do produto
        [TestMethod]
        public void ShouldReturnFiveWhenAddedPurchasedFiveItem() {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(5, _mouse.QuantityOnHand);

        }

        // ao confirmar o pedido, deve gerar um numero
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced() {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // ao pagar um pedido, o status deve ser PAGO
        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid() {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // dado 10 produtos, devem haver duas entregas
        [TestMethod]
        public void ShouldReturnTwoShippingsWhenPurchasedTenProducts() {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);


            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }
        // ao cancelar, o status deve ser CANCELADO
        public void StatusShouldBeCanceledWhenOrderCanceled() {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // ao canelar, as entregas devem ser canceladas
        public void ShouldCancelShippingsWhenOrderCanceled() {
            _order.AddItem(_mouse, 10);
            _order.Ship();
            _order.Cancel();

            foreach (var x in _order.Deliveries) {
                Assert.AreEqual(EDeliveryStatus.Canceled, x.Status);
            }
        }

    }
}
