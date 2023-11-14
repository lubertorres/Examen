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
            catch (Exception) 
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }





        [HttpPut]
        [Route("EditarNombrePelicula")]
        public async Task<IActionResult> EditarNombrePelicula(Guid movieId, string nombre)
        {

            try
            {
                var response = await _movie.EditarNombrePelicula(movieId, nombre);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }




        [HttpPut]
        [Route("EditarGeneroPelicula")]
        public async Task<IActionResult> EditarGeneroPelicula(Guid movieId, string genero)
        {

            try
            {
                var response = await _movie.EditarGeneroPelicula(movieId, genero);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }

        [HttpPut]
        [Route("EditarEdadMinimaPelicula")]
        public async Task<IActionResult> EditarEdadMinimaPelicula(Guid movieId, int permi)
        {

            try
            {
                var response = await _movie.EditarEdadMinimaPelicula(movieId, permi);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }

        [HttpPut]
        [Route("EditarDuracionPelicula")]
        public async Task<IActionResult> EditarDuracionPelicula(Guid movieId, int duracion)
        {

            try
            {
                var response = await _movie.EditarDuracionPelicula(movieId, duracion);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}














