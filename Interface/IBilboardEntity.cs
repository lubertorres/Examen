using Examen.Dtos;
using Examen.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Examen.Interface
{
    public interface IBilboardEntity
    {
        public Task<bool> EditarValidarCartelera(Guid bilboardId, bool estado, DateTime fecha);
        public Task<bool> InsertarBilboard(BillboardEntityDto billboardEntityDto);


    }


    public class BilboardP : IBilboardEntity
    {
        public BaseEntityContext _context;

        public BilboardP(BaseEntityContext context)
        {
            _context = context;

        }

        public async Task<bool> EditarValidarCartelera(Guid bilboardId, bool estado, DateTime fecha)
        {

            try
            {

                var response = await _context.BillboardEntity.FindAsync(bilboardId);

                if (response != null && response.EndTime < fecha)
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

    }
}
