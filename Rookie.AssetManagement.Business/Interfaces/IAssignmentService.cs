using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IAssignmentService
    {
        Task<AssignmentDto> AddAsync(AssignmentCreateDto assignmentRequest);
        Task<AssignmentDto> UpdateAsync(int id, AssignmentUpdateDtoRequest assetRequest);
        Task<AssignmentDto> RemoveAsync(int assignmentId);
        Task<AssignmentDto> GetByIdAsync(string assetCode);
        Task<PagedResult<AssignmentDto>> GetPaginationAsync(AssignmentRequestDto request);
        Task<PagedResponseModel<AssignmentDto>> FindByUser(AssignmentQueryCriteriaDto AssignmentRequest, CancellationToken cancellationToken);
        Task<AssignmentDto> UpdateWaitingReturningAsync(int id);

        Task<AssignmentDto> AcceptRespondAsync(int assignmentId);
        Task<AssignmentDto> DeclineRespondAsync(int assignmentId);
    }
}
