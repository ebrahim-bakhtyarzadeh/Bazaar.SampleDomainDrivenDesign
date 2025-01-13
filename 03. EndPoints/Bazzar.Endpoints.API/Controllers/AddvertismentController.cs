using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bazzar.Core.ApplicationServices.Advertisements.CommandHandlers;
using Bazzar.Core.Domain.Advertisements.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Bazzar.Endpoints.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddvertismentController : ControllerBase
    {


        [HttpPost]
        public IActionResult Post([FromServices] CreateCommandHandler handler, CreateCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("title")]
        [HttpPut]
        public IActionResult Put([FromServices] SetTitleHandler handler, SetTitleCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdateTextHandler handler, UpdateTextCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("price")]
        [HttpPut]
        public IActionResult Put([FromServices] UpdatePriceHandler handler, UpdatePriceCommand request)
        {
            handler.Handle(request);
            return Ok();
        }

        [Route("publish")]
        [HttpPut]
        public IActionResult Put([FromServices] RequestToPublishHandler handler, RequestToPublishCommand request)
        {
            handler.Handle(request);
            return Ok();
        }
    }
}
