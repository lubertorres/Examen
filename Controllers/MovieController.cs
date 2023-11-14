using Examen.Dtos;
using Examen.Interface;
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
        [Route("Genero")]
        public async Task<IActionResult> FiltrarPorGenTerror(string genero)
        {
            try
            {
                var response = await _movie.FiltrarPorGenTerror(genero);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new { ErrorMessage = "Error" });
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
            catch (Exception ex) 
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}














