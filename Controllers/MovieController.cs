using Examen.Dtos;
using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Examen.Controllers
{




    [ApiController]
    public class MovieControllerP : ControllerBase
    {
        private IMovies _movie;

        public MovieControllerP(IMovies movie)
        {
            _movie = movie;
        }


        [HttpGet]
        [Route("GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            try
            {
                var response = await _movie.GetAllMovies();
                return Ok(response);
            }
            catch (Exception)
            {
                throw new Exception("No hay registros");
            }
        }


        [HttpGet]
        [Route("Genero")]
        public async Task<IActionResult> FiltrarPorGenTerror(string genero)
        {
            try
            {
                var response = await _movie.FiltrarPorGenTerror(genero);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "No hay resultados" });
            }
        }


        [HttpPost]
        [Route("Insertar-Pelicula")]
        public async Task<IActionResult> InsertarPelicula(MovieDto movieDto)
        {

            try
            {
                var response = await _movie.InsertarPelicula(movieDto);
                return Ok(response);
            }
            catch (Exception) 
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }






        [HttpPut("EditGlobalMovie")]
        public async Task<IActionResult> EditGlobalMovie(EditMovieDto editMovieDto)
        {
            try
            {
                var response = await _movie.EditGlobalMovie(editMovieDto);
                return Ok(response);

            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }

    }
}














