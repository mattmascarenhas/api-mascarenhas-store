using MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.Handlers;
using MascarenhasStore.Domain.StoreContext.Queries;
using MascarenhasStore.Domain.StoreContext.Repositories;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using MascarenhasStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace MascarenhasStore.Api.Controllers {
    public class CustomerController : Controller {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        //construtor
        public CustomerController(ICustomerRepository repository, CustomerHandler handler) {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get() {


            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id) {
            return _repository.Get(id);

        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersQueryResult>  GetOrders(Guid id) {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("customer")]
        //[FromBody] significa que os dados do parametro esta vindo pelo corpo e nao pela url
        public object Post([FromBody] CreateCustomerCommand command) {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);

            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
        }

        [HttpPut]
        [Route("customer/{id}")]
        public IActionResult Put(Guid id, [FromBody] UpdateCustomerCommand command) {
            command.Id = id;
            var result = (UpdateCustomerCommandResult) _handler.Handle(command);

            if (_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return Ok(result);

        }

        [HttpDelete]
        [Route("customer/{id}")]
        public string Delete() {
            return null;
        }

    }
}
