using MascarenhasStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using MascarenhasStore.Domain.StoreContext.Entities;
using MascarenhasStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace MascarenhasStore.Api.Controllers {
    public class HomeController: Controller {
        [HttpGet]
        [Route("Hello")]
        public string Get() {
            return "Hello World 2";
        }


    }

}
