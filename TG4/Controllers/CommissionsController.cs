using Aplications.DataTransferObjects;
using Aplications.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TG4.Controllers
{
    
    [ApiController]
    [Route("api/v1/comissao")]
    public class CommissionsController:ControllerBase
    {
        private readonly IComissionsService _comissionsService;

        public CommissionsController(IComissionsService comissionsService)
        {
            this._comissionsService = comissionsService;
        }

        [HttpPost]
        [Route("/calcula-comissao")]
        public IActionResult CalculateCommissions([FromBody] List<SaleRequestDTO> dataTransferObject)
        {
            var result = _comissionsService.CalculateCommissions(dataTransferObject);

            return Ok(result);

        }
    }
}
