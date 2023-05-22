using MascarenhasStore.Domain.StoreContext.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Infra.Services {
    public class EmailService : IEmailService {
        public void Send(string to, string from, string subject, string body) {
            // implementar
        }
    }
}
