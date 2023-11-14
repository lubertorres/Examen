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
        public Task<List<SeatEntity>> ButacasDisponiblesSala();




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




        public async Task<List<SeatEntity>> ButacasDisponiblesSala()
        {
            using (var context = new BaseEntityContext())
            {
                DateTime today = DateTime.Today;

                var availableSeats = await context.BillboardEntity
                    .Where(b => b.DateB.Date == today)
                    .SelectMany(b => b.Room.SeatEntity)
                    .Where(s => s.Estado)
                    .ToListAsync();

                return availableSeats;
            }
        }
    }
}
