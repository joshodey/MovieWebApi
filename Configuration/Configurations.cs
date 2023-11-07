using MoviesWebApi.Entities;
using MoviesWebApi.IRepository;
using MoviesWebApi.Repisotory;

namespace MoviesWebApi.Configuration
{
    public class Configurations
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));
            services.AddControllersWithViews();

            services.AddScoped<IRepository<Movies>, Repository<Movies>>();
            services.AddScoped<IRepository<Genres>, Repository<Genres>>();
            services.AddScoped<IRepository<Ratings>, Repository<Ratings>>();
        }
    }
}
