using Examen.Dtos;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Interface
{
    public interface IBookinEntity
    {
        public Task<bool> InsertarBooking(BookingEntityDto bookingEntityDto);
        public Task<List<BookingEntity>> ListarReservas(DateTime fechaInicio, DateTime fechaFin);


    }


    public class BookingP : IBookinEntity
    {
        public BaseEntityContext _context;

        public BookingP(BaseEntityContext context)
        {
            _context = context;

        }





        public async Task<bool> InsertarBooking(BookingEntityDto bookingEntityDto)
        {
            try
            {
                var response = await _context.BookingEntity.AddAsync(new BookingEntity
                {
                    BookingId = Guid.NewGuid(),
                    DateB = DateTime.Now,
                    CustomerId = bookingEntityDto.CustomerId,
                    SeatId = bookingEntityDto.SeatId,
                    BillboardId = bookingEntityDto.BillboardId,
                    Estado = bookingEntityDto.Estado
                });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }




        public async Task<List<BookingEntity>> ListarReservas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                using (var context = new BaseEntityContext())
                {
                    var reservas = from reserva in context.BookingEntity
                                   join cartelera in context.BillboardEntity on reserva.BillboardId equals cartelera.BillboardId
                                   join pelicula in context.MovieEntity on cartelera.MovieId equals pelicula.MovieId
                                   where pelicula.Genero == "Terror" &&
                                         reserva.DateB >= fechaInicio && reserva.DateB <= fechaFin
                                   select reserva;

                    var listaReservas = reservas.ToListAsync();
                    return await listaReservas;
                }
            }catch (Exception)
            {
                return new List<BookingEntity>();
            }
        }




    }
}
