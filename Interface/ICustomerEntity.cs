using Examen.Dtos;
using Examen.Models;
using Microsoft.EntityFrameworkCore;

namespace Examen.Interface
{
    public interface ICustomerEntity
    {
        public Task<List<CustomerEntityGetAll>> GetAllCustomers();
        public Task<List<CustomerEntityGetAll>> GetCustomerById(Guid customerId);
        public Task<bool> InsertarCustomer(CustomerEntityDto customerEntityDto);
        public Task<bool> EditGlobalCliente(EditCustomerDto editCustomerDto);


    }


    public class CustomerP : ICustomerEntity
    {
        public BaseEntityContext _context;

        public CustomerP(BaseEntityContext context)
        {
            _context = context;

        }


        public async Task<List<CustomerEntityGetAll>> GetAllCustomers()
        {
            try
            {
                var customers = _context.CustomerEntity;

                var customerInfoList = await customers.Select(customer => new CustomerEntityGetAll
                {
                    DocumentNumber = customer.DocumentNumber,
                    Name = customer.Name,
                    LastName = customer.LastName,
                    Age = customer.Age,
                    PhoneNumber = customer.PhoneNumber,
                    Email = customer.Email,
                    Estado = customer.Estado,
                    DateC = customer.DateC
                }).ToListAsync();

                return customerInfoList;
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }

        }




        public async Task<List<CustomerEntityGetAll>> GetCustomerById(Guid customerId)
        {
            try
            {
                var customers = _context.CustomerEntity;

                var customerInfoList = await customers
                    .Where(customer => customer.DocumentNumber == customerId)
                    .Select(customer => new CustomerEntityGetAll
                    {
                        DocumentNumber = customer.DocumentNumber,
                        Name = customer.Name,
                        LastName = customer.LastName,
                        Age = customer.Age,
                        PhoneNumber = customer.PhoneNumber,
                        Email = customer.Email,
                        Estado = customer.Estado,
                        DateC = customer.DateC
                    })
                    .ToListAsync();
                if (customerInfoList.Count >= 1)
                {
                    return customerInfoList;


                }
                throw new Exception("No hay resultados");
            }
            catch (Exception)
            {
                throw new Exception("Error");
            }


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







        public async Task<bool> EditGlobalCliente(EditCustomerDto editCustomerDto)
        {
            try
            {
                var res = await _context.CustomerEntity.Where(x => x.DocumentNumber == editCustomerDto.DocumentNumber).FirstOrDefaultAsync();
                if (res != null)
                {
                    res.Name = editCustomerDto.Name;
                    res.LastName = editCustomerDto.LastName;
                    res.Age = editCustomerDto.Age;
                    res.PhoneNumber = editCustomerDto.PhoneNumber;
                    res.Email = editCustomerDto.Email;
                    res.Estado = editCustomerDto.Estado;
                    await _context.SaveChangesAsync();
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
