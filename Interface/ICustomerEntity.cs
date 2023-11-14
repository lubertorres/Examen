using Examen.Dtos;
using Examen.Models;

namespace Examen.Interface
{
    public interface ICustomerEntity
    {
        public Task<bool> InsertarCustomer(CustomerEntityDto customerEntityDto);
    }


    public class CustomerP : ICustomerEntity
    {
        public BaseEntityContext _context;

        public CustomerP(BaseEntityContext context)
        {
            _context = context;

        }


        public async Task<bool> InsertarCustomer(CustomerEntityDto customerEntityDto)
        {
            try
            {

                var response = await _context.CustomerEntity.AddAsync(new CustomerEntity
                {
                       
                    DocumentNumber = Guid.NewGuid(),
                    Name = customerEntityDto.Name,
                    LastName = customerEntityDto.LastName,
                    Age = customerEntityDto.Age,
                    PhoneNumber = customerEntityDto.PhoneNumber,
                    Email = customerEntityDto.Email,
                    Estado = customerEntityDto.Estado,
                    DateC = DateTime.Now

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
