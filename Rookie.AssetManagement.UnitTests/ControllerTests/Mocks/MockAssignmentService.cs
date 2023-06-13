using Moq;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts;
using Rookie.AssetManagement.Contracts.Dtos.Assignment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rookie.AssetManagement.UnitTests.ControllerTests.Mocks
{
    public class MockAssignmentService : Mock<IAssignmentService>
    {
        public MockAssignmentService MockAdddAssginment_Return_Ok(AssignmentDto assignmentDto)
        {
            Setup(x => x.AddAsync(It.IsAny<AssignmentCreateDto>())).ReturnsAsync(assignmentDto);
            return this;
        }

        public MockAssignmentService MockAdddAssginment_Return_Null()
        {
            Setup(x => x.AddAsync(It.IsAny<AssignmentCreateDto>())).ReturnsAsync((AssignmentDto)null);
            return this;
        }

        public MockAssignmentService MockGetAssignmentPaging(PagedResult<AssignmentDto> result)
        {
            Setup(x => x.GetPaginationAsync(It.IsAny<AssignmentRequestDto>())).ReturnsAsync(result);
            return this;
        }
        public MockAssignmentService MockGetAssignmentPaging_ThrowException()
        {
            Setup(x => x.GetPaginationAsync(It.IsAny<AssignmentRequestDto>())).Throws(new Exception());
            return this;
        }

        public MockAssignmentService MockDelete_ReturnOk(AssignmentDto assignmentDto)
        {
            Setup(x => x.RemoveAsync(It.IsAny<int>())).ReturnsAsync(assignmentDto);
            return this;
        }

        public MockAssignmentService MockDelete_ReturnNotFound()
        {
            Setup(x => x.RemoveAsync(It.IsAny<int>())).ReturnsAsync((AssignmentDto)null);
            return this;
        }

        public MockAssignmentService MockGetUserAssignment_ReturnOk(PagedResponseModel<AssignmentDto> result)
        {
            Setup(x => x.FindByUser(It.IsAny<AssignmentQueryCriteriaDto>(), It.IsAny<CancellationToken>())).ReturnsAsync(result);
            return this;
        }

        public MockAssignmentService MockGetUserAssignment_ReturnNull()
        {
            Setup(x => x.FindByUser(It.IsAny<AssignmentQueryCriteriaDto>(), It.IsAny<CancellationToken>())).ReturnsAsync((PagedResponseModel<AssignmentDto>)null);
            return this;
        }
        public MockAssignmentService MockUpdateWaitingReturningRequest_ReturnOk(AssignmentDto response)
        {
            Setup(x => x.UpdateWaitingReturningAsync(It.IsAny<int>())).ReturnsAsync(response);
            return this;
        }
        public MockAssignmentService MockUpdateWaitingReturningRequest_Return_NotFound()
        {
            Setup(x => x.UpdateWaitingReturningAsync(It.IsAny<int>())).ReturnsAsync((AssignmentDto)null);
            return this;
        }
    }
}
