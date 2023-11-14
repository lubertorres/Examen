using Examen.Dtos;
using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [ApiController]
    public class BilboardController : ControllerBase
    {
        private IBilboardEntity _bilboardEntity;

        public BilboardController(IBilboardEntity bilboard)
        {
            _bilboardEntity = bilboard;
        }



        [HttpPut]
        [Route("inactivar-cartelera")]
        public async Task<IActionResult> EditarValidarCartelera( Guid bilboardId, bool estado, DateTime fecha)
        {
            try
            {
                var response = await _bilboardEntity.EditarValidarCartelera(bilboardId, estado, fecha);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }

        [HttpPost]
        [Route("Insertar-Bilboard")]
        public async Task<IActionResult> InsertarBilboard(BillboardEntityDto billboardEntityDto)
        {

            //try
            //{
                var response = await _bilboardEntity.InsertarBilboard(billboardEntityDto);
                return Ok(response);
            //}
            //catch (Exception)
            //{
            //    return BadRequest(new { ErrorMessage = "Error" });
            //}
        }
    }
}
