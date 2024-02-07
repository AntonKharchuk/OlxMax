using Microsoft.AspNetCore.Mvc;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Features.AuctionFeatures;

namespace OlxMax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuctionsController : ControllerBase
    {
        private IAuctionService _auctionService;

        public AuctionsController(IAuctionService auctionService)
        {
            _auctionService = auctionService;
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
