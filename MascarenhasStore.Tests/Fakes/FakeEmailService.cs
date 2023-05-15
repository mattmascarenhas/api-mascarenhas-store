using MascarenhasStore.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Tests.Fakes {
    public class FakeEmailService : IEmailService {
        public void Send(string to, string from, string subject, string body) {
        }
    }
}
