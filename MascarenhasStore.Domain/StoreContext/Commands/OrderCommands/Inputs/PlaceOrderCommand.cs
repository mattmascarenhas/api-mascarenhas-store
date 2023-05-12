using FluentValidator;
using FluentValidator.Validation;
using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using MascarenhasStore.Shared.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Commands.OrderCommands.Inputs {
    public class PlaceOrderCommand : Notifiable, ICommand {
        public PlaceOrderCommand(){
            OrderItems = new List<OrderItemCommand>();
            
        }

        public Customer Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid() {
            //teste de validacao
            AddNotifications(new ValidationContract()
                 .Requires()
                 .HasLen(Customer.ToString(), 36, "Customer", "Identificador do Cliente inválido")
                 .IsGreaterThan(OrderItems.Count, 0, "Items", "Nenhum item do pedido foi encontrado")
           );

            return Valid();
        }
    }
    public class OrderItemCommand {
        public Guid Customer { get; set; }
        public decimal Quantity { get; set; }

    }

}
