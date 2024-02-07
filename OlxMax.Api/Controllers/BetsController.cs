using Microsoft.AspNetCore.Mvc;

using OlxMax.Business.FeatureServices.Interfaces;
using OlxMax.Dal.Features.BetFeatures;
using OlxMax.Dal.Features.UserFeatures;

namespace OlxMax.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BetsController : ControllerBase
    {
        private IBetService _betService;

        public BetsController(IBetService betService)
        {
            _betService = betService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllBetsAsync()
        {
            var bets = await _betService.GetAllBetsAsync();

            return Ok(bets);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetBetByIdAsync(int id)
        {
            var bet = await _betService.GetBetByIdAsync(id);

            return Ok(bet);
        }

        [HttpPost]

        public async Task<IActionResult> CreateNewBetAsync([FromBody] CreateBetDto createBetDto)
        {
            var bet = await _betService.AddNewBetAsync(createBetDto);

            return Ok(bet);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBetAsync([FromBody] UpdateBetDto updateBetDto)
        {
            var bet = await _betService.UpdateBetAsync(updateBetDto);
            return Ok(bet);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBetAsync(int id)
        {
            var bet = await _betService.DeleteBetAsync(id);
            return Ok(bet);
        }
    }
}
