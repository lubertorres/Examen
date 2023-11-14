using Examen.Dtos;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen.Interface
{
    public interface IRoomEntity
    {
        public Task<bool> InsertarRoom(RoomEntityDto roomEntityDto);
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
    }
}
