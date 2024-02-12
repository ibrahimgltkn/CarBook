using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public IActionResult GetCarCount()
        {
            var values = _mediator.Send(new GetCarCountQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetLocationCount")]
        public IActionResult GetLocationCount()
        {
            var values = _mediator.Send(new GetLocationCountQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetAuthorCount")]
        public IActionResult GetAuthorount()
        {
            var values = _mediator.Send(new GetAuthorCountQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetBlogCount")]
        public IActionResult GetBlogCount()
        {
            var values = _mediator.Send(new GetBlogCountQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetBrandCount")]
        public IActionResult GetBrandCount()
        {
            var values = _mediator.Send(new GetBrandCountQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetAvgRentPrizeForDaily")]
        public IActionResult GetAvgRentPrizeForDaily()
        {
            var values = _mediator.Send(new GetAvgRentPrizeForDailyQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetAvgRentPrizeForWeekly")]
        public IActionResult GetAvgRentPrizeForWeekly()
        {
            var values = _mediator.Send(new GetAvgRentPrizeForWeeklyQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetAvgRentPrizeForMonthly")]
        public IActionResult GetAvgRentPrizeForMonthly()
        {
            var values = _mediator.Send(new GetAvgRentPrizeForMonthlyQuery());
            return Ok(values.Result);
        }
        
        [HttpGet("GetCarCountByTransmissionIsAuto")]
        public IActionResult GetCarCountByTransmissionIsAuto()
        {
            var values = _mediator.Send(new GetCarCountByTransmissionIsAutoQuery());
            return Ok(values.Result);
        }
                
        [HttpGet("GetBrandNameByMaxCar")]
        public IActionResult GetBrandNameByMaxCar()
        {
            var values = _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values.Result);
        }
                        
        [HttpGet("GetBlogTitleByMaxComment")]
        public IActionResult GetBlogTitleByMaxComment()
        {
            var values = _mediator.Send(new GetBlogTitleByMaxCommentQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetCarCountBySmallerThan1000")]
        public IActionResult GetCarCountBySmallerThan1000()
        {
            var values = _mediator.Send(new GetCarCountBySmallerThan1000Query());
            return Ok(values.Result);
        }

        [HttpGet("GetCarCountByFuelGasolineOrDiesel")]
        public IActionResult GetCarCountByFuelGasolineOrDiesel()
        {
            var values = _mediator.Send(new GetCarCountByFuelGasolineOrDieselQuery());
            return Ok(values.Result);
        }
        
        [HttpGet("GetCarCountByFuelElectric")]
        public IActionResult GetCarCountByFuelElectric()
        {
            var values = _mediator.Send(new GetCarCountByFuelElectricQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMax")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMax()
        {
            var values = _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(values.Result);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDailyMin")]
        public IActionResult GetCarBrandAndModelByRentPriceDailyMin()
        {
            var values = _mediator.Send(new GetCarBrandAndModelByRentPriceDailyMaxQuery());
            return Ok(values.Result);
        }

    }
}
