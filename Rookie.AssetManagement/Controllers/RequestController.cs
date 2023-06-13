using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Dtos.RequestDtos;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly IRequestService _requestService;
        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRequest([FromQuery] ReturnRequestDto returnRequest)
        {
            try
            {
                var data = await _requestService.GetPaginationAsync(returnRequest);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

