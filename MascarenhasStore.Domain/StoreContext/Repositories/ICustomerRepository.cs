using MascarenhasStore.Domain.StoreContext.Entities;
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

    }
}
