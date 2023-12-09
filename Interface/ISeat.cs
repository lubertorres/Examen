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
        public Task<string> ButacasDisponiblesSala(Guid roomId);
        public Task<bool> EditGlobalSeat(EditGlobalSeatDto editGlobalSeatDto);


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




        public async Task<string> ButacasDisponiblesSala(Guid roomId)
        {
            try
            {
                var butacasDisponibles = await _context.RoomEntity
                    .Where(room => room.RoomId == roomId)
                    .Join(
                        _context.SeatEntity,
                        room => room.RoomId,
                        seat => seat.RoomId,
                        (room, seat) => new { Room = room, Seat = seat }
                    )
                    .GroupJoin(
                        _context.BookingEntity,
                        combined => combined.Seat.SeatId,
                        booking => booking.SeatId,
                        (combined, bookings) => new { combined.Room, combined.Seat, Bookings = bookings }
                    )
                    .SelectMany(
                        combined => combined.Bookings.DefaultIfEmpty(),
                        (combined, booking) => new { combined.Room, combined.Seat, Booking = booking }
                    )
                    .Where(combined => combined.Booking == null || combined.Booking.Estado != true)
                    .CountAsync();



                var butacasOcupadas = await _context.RoomEntity
                    .Where(room => room.RoomId == roomId)
                    .Join(
                        _context.SeatEntity,
                        room => room.RoomId,
                        seat => seat.RoomId,
                        (room, seat) => new { Room = room, Seat = seat }
                    )
                    .GroupJoin(
                        _context.BookingEntity,
                        combined => combined.Seat.SeatId,
                        booking => booking.SeatId,
                        (combined, bookings) => new { combined.Room, combined.Seat, Bookings = bookings }
                    )
                    .SelectMany(
                        combined => combined.Bookings.DefaultIfEmpty(),
                        (combined, booking) => new { combined.Room, combined.Seat, Booking = booking }
                    )
                    .Where(combined => combined.Booking != null && combined.Booking.Estado == true)
                    .CountAsync();



                return butacasDisponibles.ToString() + " Butaca(s) disponibles en la sala" + roomId.ToString() + 
                    "Butacas Ocupadas: " + butacasOcupadas.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }




        public async Task<bool> EditGlobalSeat(EditGlobalSeatDto editGlobalSeatDto)
        {
            try
            {

                var response = await _context.SeatEntity.FindAsync(editGlobalSeatDto);

                if (response != null)
                {
                    response.RowNumber = editGlobalSeatDto.RowNumber;
                    response.RoomId = editGlobalSeatDto.RoomId;
                    response.Estado = editGlobalSeatDto.Estado;
                    _context.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {
                return false;

            }
        }

    }
}
