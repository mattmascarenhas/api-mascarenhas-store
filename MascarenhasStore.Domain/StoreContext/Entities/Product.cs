using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Entities
{
    public class Product : Notifiable {
        public Product(string title, string description, string image, decimal price, decimal quantity){
            Title = title;
            Descríption = description;
            Image = image;
            Price = price;
            QuantityOnHand = quantity;
        }

        public string Title { get; private set; }
        public string Descríption { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHand { get; private set; }

        public override string ToString() {
            return Title;
        }

        public void DecreaseQuantity(decimal quantity) {
            QuantityOnHand -= quantity;
        }
    }

}
