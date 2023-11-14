using Examen.Dtos;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Examen.Interface
{
    public interface ISeat
    {
        public Task<List<SeatEntity>> FiltrarSeatsEstado(bool estado);
        public Task<bool> EditarEstadoButaca(int seatId, bool estado);
        public Task<bool> InsertarButaca(SeatDto seatDto);
        public Task<List<SeatEntity>> ListarButacasDisponiblesPorSala();



    }


    public class SeatP : ISeat
    {
        public BaseEntityContext _context;

        public SeatP(BaseEntityContext context)
        {
            _context = context;
        }

        public async Task<List<SeatEntity>> FiltrarSeatsEstado(bool estado)
        {
            try
            {
                var response = await _context.SeatEntity.Where(x => x.Estado == estado).ToListAsync();
                return response;
            }
            catch (Exception)
            {

                return new List<SeatEntity>();

            }
        }



        public async Task<bool> EditarEstadoButaca(int seatId, bool estado)
        {
            try
            {

                var response = await _context.SeatEntity.FindAsync(seatId);

                if (response != null)
                {
                    response.Estado = estado;
                    _context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }


        public async Task<bool> InsertarButaca(SeatDto seatDto)
        {
            try
            {
                var response = await _context.SeatEntity.AddAsync(new SeatEntity
                {
                    SeatId = seatDto.SeatId,
                    RowNumber = seatDto.RowNumber,
                    RoomId = seatDto.RoomId,
                    Estado = seatDto.Estado
                    
                });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //SinTer
        public async Task<List<SeatEntity>> ListarButacasDisponiblesPorSala()
        {
            DateTime fechaActual = DateTime.Now.Date;

            var seatsByRoom = from billboard in _context.BillboardEntity
                              join room in _context.RoomEntity on billboard.RoomId equals room.RoomId
                              join seat in _context.SeatEntity on room.RoomId equals seat.RoomId
                              where billboard.DateB == fechaActual
                              select seat;

            return await seatsByRoom.ToListAsync();

        }
    }
}
