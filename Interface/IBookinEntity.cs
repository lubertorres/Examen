using Examen.Dtos;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Interface
{
    public interface IBookinEntity
    {
        public Task<bool> InsertarBooking(BookingEntityDto bookingEntityDto);
        public Task<List<BookingEntity>> ListarReservasTerror(DateTime fechaInicio, DateTime fechaFin, string genero);
        public Task<List<BookingEntity>> GetAllReservasUser(Guid customerId);
        public Task<bool> InactivarReservaYButaca(Guid bookingId, int seatId);

        public Task<bool> EditarIdCliente(Guid bookingId, Guid DocumentNumber);
        public Task<bool> EditarSeatId(Guid bookingId, int seatId);





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




        public async Task<List<BookingEntity>> ListarReservasTerror(DateTime fechaInicio, DateTime fechaFin, string genero)
        {
            try
            {
                using (var context = new BaseEntityContext())
                {
                    var reservas = await (
                        from reserva in context.BookingEntity
                        join cartelera in context.BillboardEntity on reserva.BillboardId equals cartelera.BillboardId
                        join pelicula in context.MovieEntity on cartelera.MovieId equals pelicula.MovieId
                        where pelicula.Genero == genero &&
                              reserva.DateB >= fechaInicio && reserva.DateB <= fechaFin
                        select reserva
                    ).ToListAsync();

                    return reservas;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al listar reservas: {ex.Message}");
                throw;
            }
        }



        public async Task<List<BookingEntity>> GetAllReservasUser(Guid customerId)
        {
            try
            {
                var response = await _context.BookingEntity.Where(x => x.CustomerId == customerId).ToListAsync();
                return response;
            }
            catch (Exception)
            {
                return new List<BookingEntity>();
            }
        }


        public async Task<bool> InactivarReservaYButaca(Guid bookingId, int seatId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var booking = _context.BookingEntity.FirstOrDefault(x => x.BookingId == bookingId);
                    if (booking == null)
                    {
                        throw new Exception("Reserva no encontrada");
                    }

                    // Obtener la butaca asociada
                    var seat = _context.SeatEntity.FirstOrDefault(x => x.SeatId == seatId);
                    if (seat == null)
                    {
                        throw new Exception("Butaca no encontrada");
                    }

                    // Deshabilitar la reserva y la butaca
                    booking.Estado = false;
                    seat.Estado = false;

                    // Guardar los cambios en la base de datos
                    await _context.SaveChangesAsync();

                    // Confirmar la transacción
                    transaction.Commit();
                    return true;
                }
                catch (Exception)
                {
                    // Algo salió mal, deshacer la transacción
                    transaction.Rollback();
                    throw; // Propagar la excepción para manejarla en un nivel superior si es necesario
                }
            }
        }



        public async Task<bool> EditarIdCliente(Guid bookingId, Guid DocumentNumber)
        {
            try
            {
                var response = await _context.BookingEntity.FindAsync(bookingId);

                if (response != null)
                {
                    response.CustomerId = DocumentNumber;
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



        public async Task<bool> EditarSeatId(Guid bookingId, int seatId)
        {
            try
            {
                var response = await _context.BookingEntity.FindAsync(bookingId);

                if (response != null)
                {
                    response.SeatId = seatId;
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
