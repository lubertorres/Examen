﻿using Examen.Dtos;
using Examen.Interface;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Examen.Controllers
{
    [ApiController]
    public class SeatControllerP : ControllerBase
    {
        private ISeat _seat;

        public SeatControllerP(ISeat seat)
        {
            _seat = seat;
        }





        [HttpGet]
        [Route("filtrar-por-estado")]
        public async Task<IActionResult> FiltrarSeatsEstado([FromQuery] bool estado)
        {
            try
            {
                var response = await _seat.FiltrarSeatsEstado(estado);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }


        }


        [HttpPut]
        [Route("editar-estado-butaca")]
        public async Task<IActionResult> EditarEstadoButaca(int seatId, bool estado)
        {

            try
            {
                var response = await _seat.EditarEstadoButaca(seatId, estado);
                return Ok(response);

            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }

        }


        [HttpPost]
        [Route("Insertar-Butaca")]
        public async Task<IActionResult> InsertarButaca(SeatDto seatDto)
        {

            try
            {
                var response = await _seat.InsertarButaca(seatDto);
                return Ok(response);

            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }

        }






        [HttpGet]
        [Route("ButacasDisponiblesSala")]
        public async Task<IActionResult> ButacasDisponiblesYOcupadasSala(Guid roomId)
        {
            var response = await _seat.ButacasDisponiblesSala(roomId);
            return Ok(response);
        }




        [HttpPut("EditGlobalSeat")]
        public async Task<IActionResult> EditGlobalSeat(EditGlobalSeatDto editGlobalSeatDto)
        {

            try
            {
                var response = await _seat.EditGlobalSeat(editGlobalSeatDto);
                return Ok(response);

            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }

        }

    }



}
