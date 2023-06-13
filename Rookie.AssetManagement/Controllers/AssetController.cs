using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rookie.AssetManagement.Business.Interfaces;
using Rookie.AssetManagement.Business.Services;
using Rookie.AssetManagement.Contracts.Dtos.Asset;
using Rookie.AssetManagement.DataAccessor.Entities;

namespace Rookie.AssetManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : ControllerBase
    {
        private readonly IAssetService _assetService;

        public AssetController(IAssetService assetService)
        {
            _assetService = assetService;
        }

        [HttpGet("")]
        public async Task<ActionResult> GetAssetList([FromQuery] AssetRequestDto request)
        {
            try
            {
                var data = await _assetService.GetPaginationAsync(request);
                return Ok(data);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpGet("GetAssetById")]
        public async Task<IActionResult> GetAssetById(string assetCode)
        {
            var assetFind = await _assetService.GetByIdAsync(assetCode);
            if (assetFind == null)
            {
                return NotFound();
            }
            return Ok(assetFind);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsset(AssetCreateDto asset)
        {
            var assetAdd = _assetService.AddAsync(asset);
            return Ok(assetAdd);
        }

        [HttpPut("{assetCode}")]
        public async Task<ActionResult<AssetDto>> UpdateAsset([FromRoute] string assetCode,[FromBody] AssetUpdateDto assetRequest)
        {
            var assetUpdate = await _assetService.UpdateAsync(assetCode, assetRequest);
            if (assetUpdate == null)
                return NotFound();
            return Ok(assetUpdate);
        }

        [HttpDelete("{assetCode}")]
        public async Task<IActionResult> RemoveAsset([FromRoute] string assetCode)
        {
            var assetRemoved = await _assetService.RemoveAsync(assetCode);
            return Ok(assetRemoved);
        }

    }
}

