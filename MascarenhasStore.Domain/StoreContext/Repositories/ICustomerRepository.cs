using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Domain.StoreContext.Repositories {
    public interface ICustomerRepository {
        bool CheckDocument(string document);
        bool CheckEmail(string email);
        void Save(Customer customer);
        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
        IEnumerable<ListCustomerQueryResult> Get();
        GetCustomerQueryResult Get(Guid id);
        IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id);
    }
}
