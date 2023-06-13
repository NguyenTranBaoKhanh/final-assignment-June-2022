using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Contracts.Dtos.Assignment;
using System.Threading;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        public AssignmentController(IAssignmentService assignmentService)
        {
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAssignment([FromQuery] AssignmentRequestDto assignmentRequest)
        {
            try
            {
                var data = await _assignmentService.GetPaginationAsync(assignmentRequest);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("findByUser")]
        [Authorize]
        public async Task<IActionResult> GetAssignmentByUser([FromQuery] AssignmentQueryCriteriaDto assignmentRequest, CancellationToken cancellationToken)
        {
            try
            {
                var data = await _assignmentService.FindByUser(assignmentRequest, cancellationToken);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddAssignment(AssignmentCreateDto assignmentCreateDto)
        {
            var assetAdd = await _assignmentService.AddAsync(assignmentCreateDto);
            if (assetAdd == null) return NotFound();
            return Ok(assetAdd);
        }

        [HttpDelete("{assignmentId}")]
        public async Task<IActionResult> RemoveAssignment([FromRoute] int assignmentId)
        {
            var assignmentRemoved = await _assignmentService.RemoveAsync(assignmentId);
            return Ok(assignmentRemoved);
        }

        [HttpPut("UpdateWaitingReturn/{id}")]
        public async Task<IActionResult> UpdateWaitingReturning(int id)
        {
            var assignmentDto = await _assignmentService.UpdateWaitingReturningAsync(id);
            if (assignmentDto == null)
                return NotFound();
            return Ok(assignmentDto);
        }

        [HttpPut("Accept/{assignmentId}")]
        public async Task<IActionResult> AcceptResponsd([FromRoute] int assignmentId)
        {

            var result = await _assignmentService.AcceptRespondAsync(assignmentId);
            if (result == null) { return NotFound(); }
            return Ok(result);

        }

        [HttpPut("Decline/{assignmentId}")]
        public async Task<IActionResult> DeclineResponsd([FromRoute] int assignmentId)
        {

            var result = await _assignmentService.DeclineRespondAsync(assignmentId);
            if (result == null) { return NotFound(); }
            return Ok(result);

        }

        [HttpPut("{assignmentId}")]
        public async Task<ActionResult> UpdateAssignment([FromRoute] int assignmentId, [FromBody] AssignmentUpdateDtoRequest assignmentUpdateDto)
        {
            var assignment = await _assignmentService.UpdateAsync(assignmentId, assignmentUpdateDto);

            return Ok(assignment);
        }
    }
}
