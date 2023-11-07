using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi.DTO;
using MoviesWebApi.Entities;
using MoviesWebApi.IRepository;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IRepository<Movies> context;
        private readonly IMapper map;

        public MoviesController(IRepository<Movies> context, IMapper map)
        {
            this.context = context;
            this.map = map;
        }

        [HttpGet("get-all-movies")]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var data = await context.GetAllAsync();
                var mapData = map.Map<List<MoviesDto>>(data);
                return Ok(mapData);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("get-movie")]
        public async Task<IActionResult> GetMovie(string Id, CancellationToken token)
        {
            try
            {
                var data = await context.GetAsync(Id);
                var mapData = map.Map<MoviesDto>(data);

                return mapData is not null ? Ok(mapData) : NotFound();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMovies(MoviesDto movies, CancellationToken token)
        {
            try
            {
                var mapData = map.Map<Movies>(movies);

                return await context.AddAsync(mapData, token) is not null? Ok(movies) : Problem("Error occured");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie(MoviesDto movie, string Id, CancellationToken token)
        {
            try
            {
                var data = await context.GetAsync(Id);

                data.TicketPrice = movie.TicketPrice == 0? data.TicketPrice : movie.TicketPrice;
                data.Description = string.IsNullOrWhiteSpace(movie.Description)? data.Description : movie.Description;
                data.ImageUrl = string.IsNullOrWhiteSpace(movie.ImageUrl)? data.ImageUrl : movie.ImageUrl;
                data.Genre = movie.Genre is not null? movie.Genre : data.Genre;
                data.Country = string.IsNullOrWhiteSpace(movie.Country)? data.Country : movie.Country;
                data.Ratings = movie.Ratings is null? data.Ratings : movie.Ratings;

                var result = await context.UpdateAsync(data, token);

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveMovie(string Id, CancellationToken token)
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
