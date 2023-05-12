using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.ValueObjects;

namespace MascarenhasStore.Tests;

[TestClass]
public class UnitTest1 {
    [TestMethod]
    public void TestMethod1() {
        //dados do cliente
        var name = new Name("", "M");
        var document = new Document("43243242");
        var email = new Email("mattmascarenhaas7@gmail.com");
        var c = new Customer(name, document, email, "999999999");
        //cadastrando os produtos no estoque
        var teclado = new Product("Teclado", "Teclado mecanico", "image.png", 120.90m, 32);
        var mouse = new Product("Mouse", "Mouse Gamer", "image.png", 100.50m, 20);
        var monitor = new Product("Monitor", "Monitor gamer", "image.png", 800.90m, 12);
        //criando uma ordem de pedido com o produtos que estao em estoque
        var order = new Order(c);
        //order.AddItem(new OrderItem(teclado,2));
        //order.AddItem(new OrderItem(mouse, 2));
        //order.AddItem(new OrderItem(monitor, 1));


        //realizar o pedido
        order.Place();
        //varificar se o pedido e valido
        var valid = order.IsValid;
        //simular o pgamentos
        order.Pay();
        //simular o envio
        order.Ship();
        //simular o cancelamento
        order.Cancel();

    }
}