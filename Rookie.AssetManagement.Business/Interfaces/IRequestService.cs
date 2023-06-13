using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.RequestDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.Business.Interfaces
{
    public interface IRequestService
    {
        Task<PagedResult<RequestDto>> GetPaginationAsync(ReturnRequestDto request);
        Task<RequestDto> AddAsync(RequestCreateDto assignmentRequest);
        Task<RequestDto> UpdateAsync(RequestUpdateDto assetRequest);
        Task<RequestDto> RemoveAsync(int requesttId);
        Task<RequestDto> GetByIdAsync(int id);
    }
}
