using Examen.Dtos;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen.Interface
{
    public interface IRoomEntity
    {
        public Task<bool> InsertarRoom(RoomEntityDto roomEntityDto);
        public Task<List<RoomEntity>> GetAllRoom();
        public Task<bool> EditGlobalRoom(EditGlobalRoomDto editGlobalRoomDto);




    }

    public class RoomEntityP : IRoomEntity
    {
        public BaseEntityContext _context;

        public RoomEntityP(BaseEntityContext context)
        {
            _context = context;

        }





        public async Task<bool> InsertarRoom(RoomEntityDto roomEntityDto)
        {
            try
            {
                var response = await _context.RoomEntity.AddAsync(new RoomEntity
                {
                    RoomId = Guid.NewGuid(),
                    Name = roomEntityDto.Name,
                    Number = roomEntityDto.Number

                });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<RoomEntity>> GetAllRoom()
        {
            try
            {
                var response = await _context.RoomEntity.ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<RoomEntity>();
            }
        }




        public async Task<bool> EditGlobalRoom(EditGlobalRoomDto editGlobalRoomDto)
        {
            try
            {
                var response = await _context.RoomEntity.FindAsync(editGlobalRoomDto.RoomId);

                if (response != null)
                {
                    response.Name = editGlobalRoomDto.Name;
                    response.Number = editGlobalRoomDto.Number;
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
