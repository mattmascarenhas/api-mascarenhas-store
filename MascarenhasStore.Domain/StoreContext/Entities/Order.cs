using FluentValidator;
using MascarenhasStore.Domain.StoreContext.Enum;
using MascarenhasStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Entities
{
    public class Order : Entity {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        //construtor
        public Order(Customer customer){
            Customer = customer;
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        //propriedades
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        //IReadOnlyCollection é tipo um IList que faz apenas leitura, ele nao permite utilizar os metodos do IList
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        //metodos
        //unico metodo que irá adicionar um pedido
        public void AddItem(Product product, decimal quantity) {
            //valida o item
            if (quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque");
            //adicona ao pedido
            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }

        //criar um pedido
        public void Place() {
            //gera o numero do pedido
            Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            //validar
            if (_items.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");
        }
        //pagar um pedido
        public void Pay() {
            Status = EOrderStatus.Paid;
            var delivery = new Delivery(DateTime.Now.AddDays(5));
            delivery.Ship();
            _deliveries.Add(delivery);
        }
        //enviar um pedido
        public void Ship() {
            //a cada 5 produtos é uma entrega
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5))); //teste ja para iniciar com uma entrega
            var count = 1;

            //a cada 5 produtos quebra as entregas
            foreach (var item in _items) {
                if (count == 5) {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            //envia todas as entregas
            deliveries.ForEach(x => x.Ship());
            //adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }
        //cancelar um pedido
        public void Cancel() {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}
