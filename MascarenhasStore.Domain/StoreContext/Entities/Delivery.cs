using FluentValidator;
using MascarenhasStore.Domain.StoreContext.Enum;
using MascarenhasStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Entities {
    public class Delivery : Entity {
        public Delivery(DateTime estimatedDeliveryDate) {
            CreatedDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }
        public DateTime CreatedDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship() {
            //se a data de entrega for no passado, nao entregar
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel() {
            //se os status ja foi entregue, nao pode cancelar
            Status = EDeliveryStatus.Canceled;

        }
    }
}
