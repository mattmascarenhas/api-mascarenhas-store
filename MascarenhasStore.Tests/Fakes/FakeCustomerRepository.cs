using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Tests.Fakes {
    public class FakeCustomerRepository : ICustomerRepository {
        public bool CheckDocument(string document) {
            return false;
        }

        public bool CheckEmail(string email) {
            return false;
        }

        public void Save(Customer customer) {

        }
    }
}
