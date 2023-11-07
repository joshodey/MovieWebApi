using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoviesWebApi.DTO;
using MoviesWebApi.Entities;
using MoviesWebApi.IRepository;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRepository<Ratings> context;


        public RatingsController(IRepository<Ratings> context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            try
            {
                var data = await context.GetAllAsync();

                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("get-rating")]
        public async Task<IActionResult> GetRatings(int Id)
        {
            try
            {
                var data = await context.GetAsync(Id);

                return Ok(data);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRatings(Ratings genre, CancellationToken token)
        {
            try
            {
                var data = await context.AddAsync(genre, token);

                return data is not null ? Ok(data) : Problem("Error Occured");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRatings(UpdateRatingsDto ratings, int Id, CancellationToken token)
        {
            try
            {
                var data = await context.GetAsync(Id);

                data.comment = string.IsNullOrWhiteSpace(ratings.comment) ? data.comment : ratings.comment;
                data.Value = ratings.Value == 0 ? data.Value: ratings.Value;

                var result = await context.UpdateAsync(data, token);

                return Ok(result);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveRatings(int Id, CancellationToken token)
        {
            try
            {
                var data = await context.GetAsync(Id);

                var result = await context.DeleteAsync(data);

                return Ok(result);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
