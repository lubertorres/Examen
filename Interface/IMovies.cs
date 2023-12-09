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
        public Task<bool> EditarNombrePelicula(Guid movieId, string name);
        public Task<bool> EditarGeneroPelicula(Guid MovieId, string genero);
        public Task<bool> EditarEdadMinimaPelicula(Guid MovieId, int permi);
        public Task<bool> EditarDuracionPelicula(Guid MovieId, int duracion);






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

        public async Task<bool> EditarNombrePelicula(Guid MovieId, string name)
        {
            try
            {
                var response = await _context.MovieEntity.FindAsync(MovieId);

                if (response != null)
                {
                    response.Name = name;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }


        public async Task<bool> EditarGeneroPelicula(Guid MovieId, string genero)
        {
            try
            {
                var response = await _context.MovieEntity.FindAsync(MovieId);

                if (response != null)
                {
                    response.Genero = genero;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public async Task<bool> EditarEdadMinimaPelicula(Guid MovieId, int permi)
        {
            try
            {
                var response = await _context.MovieEntity.FindAsync(MovieId);

                if (response != null)
                {
                    response.AllowedAge = permi;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }


        public async Task<bool> EditarDuracionPelicula(Guid MovieId, int duracion)
        {
            try
            {
                var response = await _context.MovieEntity.FindAsync(MovieId);

                if (response != null)
                {
                    response.LengthMinutes = duracion;
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }
    }
}
