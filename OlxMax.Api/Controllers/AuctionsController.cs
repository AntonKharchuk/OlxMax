using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.Identity.Client;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Business.FeatureServices.Realizations;
using OlxMax.Dal.Features.AuctionFeatures;
using OlxMax.Dal.Features.AuctionImages;

using System.ComponentModel.DataAnnotations;

namespace OlxMax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController : ControllerBase
    {
        private IAuctionService _auctionService;
        private IAuctionImageService _auctionImageService;

        public AuctionsController(IAuctionService auctionService, IAuctionImageService auctionImageService)
        {
            _auctionService = auctionService;
            _auctionImageService = auctionImageService;
        }

        [HttpDelete("{id}/images/{imageId}")]
        public async Task<IActionResult> DeleteAuctionImageAsync(int id, int imageId)
        {
            var auctionImage = await _auctionImageService.DeleteAuctionImageAsync(id);
            return Ok(auctionImage);
        }
        [HttpPut("{id}/images")]
        public async Task<IActionResult> AddNewAuctionImageAsync(int id, [FromBody] CreateAuctionImageDto createAuctionImageDto)
        {
            if (id!= createAuctionImageDto.AuctionId)
            {
                throw new ValidationException("'id' and 'AuctionImage.AuctionId' missmatch");
            }
            var auctionImage = await _auctionImageService.AddNewAuctionImageAsync(createAuctionImageDto);
            return Ok(auctionImage);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAuctionsAsync()
        {
            var auctions = await _auctionService.GetAllAuctionsAsync();

            return Ok(auctions);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetAuctionByIdAsync(int id)
        {
            var auction = await _auctionService.GetAuctionByIdAsync(id);

            return Ok(auction);
        }

        [HttpPost]

        public async Task<IActionResult> CreateNewAuctionAsync([FromBody] CreateAuctionDto createAuctionDto)
        {
            var auction = await _auctionService.AddNewAuctionAsync(createAuctionDto);

            return Ok(auction);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAuctionAsync([FromBody] UpdateAuctionDto updateAuctionDto)
        {
            var auction = await _auctionService.UpdateAuctionAsync(updateAuctionDto);
            return Ok(auction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuctionAsync(int id)
        {
            var auction = await _auctionService.DeleteAuctionAsync(id);
            return Ok(auction);
        }
    }
}
