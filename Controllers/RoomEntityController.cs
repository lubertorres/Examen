using Examen.Dtos;
using Examen.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [ApiController]
    public class RoomEntityController : ControllerBase
    {
        private IRoomEntity _roomEntity;

        public RoomEntityController(IRoomEntity roomEntity)
        {
            _roomEntity = roomEntity;
        }



        [HttpPost]
        [Route("InsertarRoom")]
        public async Task<IActionResult> InInsertarRoom(RoomEntityDto roomEntityDto)
        {
            try
            {
                var response = await _roomEntity.InsertarRoom(roomEntityDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });

            }
        }



    }
}
