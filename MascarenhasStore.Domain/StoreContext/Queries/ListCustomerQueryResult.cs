using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Queries {
    public class ListCustomerQueryResult {
         public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}
