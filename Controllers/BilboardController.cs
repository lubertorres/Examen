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
        public async Task<IActionResult> EditarValidarCartelera( Guid bilboardId)
        {
            try
            {
                var response = await _bilboardEntity.EditarValidarCartelera(bilboardId);
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





        [HttpPut("EditGlobalBillboard")]
        public async Task<IActionResult> EditGlobalBillboard(EditBillboardDto editBillboardDto)
        {

            try
            {
                var response = await _bilboardEntity.EditGlobalBillboard(editBillboardDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }


        [HttpGet]
        [Route("Listar-Todas-Las-carteleras")]
        public async Task<IActionResult> GetAllBilboards()
        {
            try
            {
                var response = await _bilboardEntity.GetAllBilboards();
                return Ok(response);
                if (response.Count >= 1)
                {
                    return Ok(response);

                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                throw new Exception("No hay resultados");
            }
        }


        [HttpGet]
        [Route("Listar-Carteleras-Por-Id")]
        public async Task<IActionResult> GetBilboardById(Guid bilboardId)
        {
            try
            {
                var response = await _bilboardEntity.GetBilboardById(bilboardId);
                return Ok(response);
                if (response.Count >= 1)
                {
                    return Ok(response);
                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "No hay resultados" });
            }
        }



        [HttpPut]
        [Route("InactivarCartelerayReservas")]
        public async Task<IActionResult> InactivarCartelerayReservas(Guid bilboardId)
        {
            try
            {
                var response = await _bilboardEntity.InactivarCartelerayReservas(bilboardId);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}
