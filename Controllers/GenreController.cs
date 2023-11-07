using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesWebApi.DTO;
using MoviesWebApi.Entities;
using MoviesWebApi.IRepository;

namespace MoviesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IRepository<Genres> context;


        public GenreController(IRepository<Genres> context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
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

        [HttpGet("get-genre")]
        public async Task<IActionResult> GetGenres(int Id)
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
        public async Task<IActionResult> AddGenre(Genres genre, CancellationToken token)
        {
            try
            {
                var data = await context.AddAsync(genre, token);

                return data is not null? Ok(data) : Problem("Error Occured");
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGenre(UpdateGenreDto genre, int Id, CancellationToken token)
        {
            try
            {
                var data = await context.GetAsync(Id);

                data.Title = string.IsNullOrWhiteSpace(genre.Title)? data.Title : genre.Title;
                data.Description = string.IsNullOrWhiteSpace(genre.Description)? data.Description : genre.Description;

                var result = await context.UpdateAsync(data, token);

                return Ok(result);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveGenre(int Id, CancellationToken token)
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
