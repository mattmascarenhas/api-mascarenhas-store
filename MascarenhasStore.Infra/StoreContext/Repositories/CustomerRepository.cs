using Dapper;
using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.Queries;
using MascarenhasStore.Domain.StoreContext.Repositories;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using MascarenhasStore.Infra.StoreContext.DataContexts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace MascarenhasStore.Infra.StoreContext.Repositories {
    public class CustomerRepository : ICustomerRepository {
        private readonly MascarenhasDataContext _context;
        public CustomerRepository(MascarenhasDataContext context) {
            _context = context;
        }
        //excutando um procedure
        public bool CheckDocument(string document) {
            return _context
                .Connection  //nome da procedure, o parametro, especificar o tipo, para nao executar como uma query
                .Query<bool>("spCheckDocument", new {
                    Document = document
                }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email) {
            return _context
                .Connection
                .Query<bool>("spCheckEmail", new {
                    Email = email
                }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerQueryResult> Get() {
            return _context
                .Connection  //nome da procedure, o parametro, especificar o tipo, para nao executar como uma query
                .Query<ListCustomerQueryResult>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Document], [Email] FROM [Customer]");
        }

        public GetCustomerQueryResult Get(Guid id) {
            return _context
               .Connection  //nome da procedure, o parametro, especificar o tipo, para nao executar como uma query
               .Query<GetCustomerQueryResult>("SELECT [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Document], [Email] FROM [Customer] WHERE [Id]=@id",
               new {
                   id = id
               })
               .FirstOrDefault();
        }

        //falta criar a procedure para executar essa funcao
        public CustomerOrdersCountResult GetCustomerOrdersCount(string document) {
            return _context
                .Connection
                .Query<CustomerOrdersCountResult>("spGetCustomerOrdersCount", new {
                    Document = document
                }, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetOrders(Guid id) {
            return _context
                    .Connection  //nome da procedure, o parametro, especificar o tipo, para nao executar como uma query
                    .Query<ListCustomerOrdersQueryResult>("",
                    new { id = id });
        }

        public void Save(Customer customer) {
            _context.Connection.Execute("spCreateCustomer", new {
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document,
                Email = customer.Email,
                Phone = customer.Phone

            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses) {
                _context.Connection.Execute("spCreateAddress", new {
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type

                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
