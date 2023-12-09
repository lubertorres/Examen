using Examen.Dtos;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Interface
{
    public interface IMovies
    {
        public Task<List<MovieGetDto>> GetAllMovies();
        public Task<List<MovieGetDto>> FiltrarPorGenTerror(string genero);
        public  Task<bool> InsertarPelicula(MovieDto movieDto);
        public Task<bool> EditGlobalMovie(EditMovieDto editMoveDto);



    }


    public class MoviesP : IMovies
    {
        public BaseEntityContext _context;

        public MoviesP(BaseEntityContext context)
        {
            _context = context;

        }

        public async Task<List<MovieGetDto>> GetAllMovies()
        {
            try
            {
                var customers = _context.MovieEntity;

                var customerInfoList = await customers
                    .Select(movie => new MovieGetDto
                    {
                        MovieId = movie.MovieId,
                        Name = movie.Name,
                        Genero = movie.Genero,
                        AllowedAge = movie.AllowedAge,
                        LengthMinutes = movie.LengthMinutes,
                        DateB = movie.DateB
                    })
                    .ToListAsync();
                if (customerInfoList.Count >= 1)
                {
                    return customerInfoList;


                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<MovieGetDto>> FiltrarPorGenTerror(string genero)
        {
            try
            {

                var customers = _context.MovieEntity;

                var customerInfoList = await customers
                    .Where(x => x.Genero == genero)
                    .Select(movie => new MovieGetDto
                    {
                        MovieId = movie.MovieId,
                        Name = movie.Name,
                        Genero = movie.Genero,
                        AllowedAge = movie.AllowedAge,
                        LengthMinutes = movie.LengthMinutes,
                        DateB = movie.DateB
                    })
                    .ToListAsync();
                if (customerInfoList.Count >= 1)
                {
                    return customerInfoList;


                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                throw;
            }
        }




        public async Task<bool> InsertarPelicula(MovieDto movieDto)
        {
            try
            {

                var response = await _context.MovieEntity.AddAsync(new MovieEntity {
                    MovieId = Guid.NewGuid(),
                    Name = movieDto.Name,
                    Genero = movieDto.Genero,
                    AllowedAge = movieDto.AllowedAge,
                    LengthMinutes = movieDto.LengthMinutes,
                    DateB = DateTime.Now,

                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        public async Task<bool> EditGlobalMovie(EditMovieDto editMovieDto)
        {
            try
            {
                var response = await _context.MovieEntity.Where(x => x.MovieId == editMovieDto.Id).FirstOrDefaultAsync();
                if (response != null)
                {
                    response.Name = editMovieDto.Name;
                    response.Genero = editMovieDto.Genero;
                    response.AllowedAge = editMovieDto.AllowedAge;
                    response.LengthMinutes = editMovieDto.LengthMinutes;
                    await _context.SaveChangesAsync();
                }
                return true;
            }catch (Exception)
            {
                return false;
            }

        }
    }
}
