using Examen.Dtos;
using Examen.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen.Interface
{
    public interface IBilboardEntity
    {
        public Task<bool> EditarValidarCartelera(Guid bilboardId);
        public Task<bool> InsertarBilboard(BillboardEntityDto billboardEntityDto);
        public Task<List<BilboardEntityGetAll>> GetAllBilboards();
        public Task<List<BilboardEntityGetAll>> GetBilboardById(Guid bilboardId);
        public Task<bool> InactivarCartelerayReservas(Guid bilboardId);
        public Task<bool> EditGlobalBillboard(EditBillboardDto editBillboardDto);


    }


    public class BilboardP : IBilboardEntity
    {
        public BaseEntityContext _context;

        public BilboardP(BaseEntityContext context)
        {
            _context = context;

        }

        public async Task<bool> EditarValidarCartelera(Guid bilboardId)
        {

            try
            {
                var fechaHoy = DateTime.Now;
                var response = await _context.BillboardEntity.FindAsync(bilboardId);

                if (response != null && response.StartTime < fechaHoy)
                {
                    response.Estado = false;
                    _context.SaveChanges();
                    return true;

                }
                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }



        public async Task<bool> InsertarBilboard(BillboardEntityDto billboardEntityDto)
        {
            try
            {
                var response = await _context.BillboardEntity.AddAsync(new BillboardEntity
                {
                    BillboardId = Guid.NewGuid(),
                    DateB = DateTime.Now,
                    StartTime = billboardEntityDto.StartTime,
                    EndTime = billboardEntityDto.EndTime,
                    MovieId = billboardEntityDto.MovieId,
                    RoomId = billboardEntityDto.RoomId,
                    Estado = billboardEntityDto.Estado
                });

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }






        public async Task<bool> EditGlobalBillboard(EditBillboardDto editBillboardDto)
        {
            try
            {
                var response = await _context.BillboardEntity.FindAsync(editBillboardDto.BillboardId);

                if (response != null)
                {
                    response.StartTime = editBillboardDto.StartTime;
                    response.EndTime = editBillboardDto.EndTime;
                    response.MovieId = editBillboardDto.MovieId;
                    response.RoomId = editBillboardDto.RoomId;
                    response.Estado =  editBillboardDto.Estado;
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




        public async Task<List<BilboardEntityGetAll>> GetAllBilboards()
        {
            try
            {
                var billboards = _context.BillboardEntity;

                var bilboardInfoList = await billboards.Select(billboard => new BilboardEntityGetAll
                {
                    BillboardId = billboard.BillboardId,
                    DateB = billboard.DateB,
                    StartTime = billboard.StartTime,
                    EndTime = billboard.EndTime,
                    MovieId = billboard.MovieId,
                    RoomId = billboard.RoomId,
                    Estado = billboard.Estado

                }).ToListAsync();

                if (bilboardInfoList.Count >= 1)
                {
                    return bilboardInfoList;
                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                throw new Exception("No hay resultados");
            }

        }


        public async Task<List<BilboardEntityGetAll>> GetBilboardById(Guid billboardId)
        {
            try
            {
                var billboards = _context.BillboardEntity;

                var bilboardInfoList = await billboards
                    .Where(billboard => billboard.BillboardId == billboardId)
                    .Select(billboard => new BilboardEntityGetAll
                    {
                        BillboardId = billboard.BillboardId,
                        DateB = billboard.DateB,
                        StartTime = billboard.StartTime,
                        EndTime = billboard.EndTime,
                        MovieId = billboard.MovieId,
                        RoomId = billboard.RoomId,
                        Estado = billboard.Estado

                    }).ToListAsync();
                if (bilboardInfoList.Count >= 1)
                {
                    return bilboardInfoList;
                }
                throw new Exception("No hay resultados");

            }
            catch (Exception)
            {
                throw new Exception("No hay resultados");
            }


        }

        public async Task<bool> InactivarCartelerayReservas(Guid bilboardId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var billboard = _context.BillboardEntity.FirstOrDefault(x => x.BillboardId == bilboardId);
                    if (billboard == null)
                    {
                        throw new Exception("Reserva no encontrada");
                    }


                    // Deshabilitar la reserva y la butaca
                    billboard.Estado = false;

                    var res = await _context.BookingEntity.Where(x => x.BillboardId == bilboardId).ToListAsync();
                    Console.WriteLine("Id cliente afectado: ");

                    foreach (var item in res)
                    {
                        item.Estado = false;
                        Console.WriteLine("Id cliente afectado: " + item.CustomerId);
                    }

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
    }
}
