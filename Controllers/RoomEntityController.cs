using Examen.Dtos;
using Examen.Interface;
using Examen.Models;
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



        [HttpGet]
        [Route("GetAllRoom")]
        public async Task<IActionResult> GetAllRoom()
        {

            try
            {
                var response = await _roomEntity.GetAllRoom();
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }

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



        [HttpPut("EditGlobalRoom")]
        public async Task<IActionResult> EditGlobalRoom(EditGlobalRoomDto editGlobalRoomDto)
        {

            try
            {
                var response = await _roomEntity.EditGlobalRoom(editGlobalRoomDto);
                return Ok(response);
            }
            catch (Exception)
            {
                return BadRequest(new { ErrorMessage = "Error" });
            }
        }
    }
}
