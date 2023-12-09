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
        public Task<bool> EditarNombreCliente(Guid DocumentNumber, string nombre);
        public Task<bool> EditarApellidoCliente(Guid DocumentNumber, string apellido);
        public Task<bool> EditarEdadCliente(Guid DocumentNumber, int edad);
        public Task<bool> EditarPhoneCliente(Guid DocumentNumber, string num);
        public Task<bool> EditarEmailCliente(Guid DocumentNumber, string email);
        public Task<bool> EditarEstadoCliente(Guid DocumentNumber, bool estado);


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





        public async Task<bool> EditarNombreCliente(Guid DocumentNumber, string nombre)
        {
            try
            {
                var response = await _context.CustomerEntity.FindAsync(DocumentNumber);

                if (response != null)
                {
                    response.Name = nombre;
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


        public async Task<bool> EditarApellidoCliente(Guid DocumentNumber, string apellido)
        {
            try
            {
                var response = await _context.CustomerEntity.FindAsync(DocumentNumber);

                if (response != null)
                {
                    response.LastName = apellido;
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

        public async Task<bool> EditarEdadCliente(Guid DocumentNumber, int edad)
        {
            try
            {
                var response = await _context.CustomerEntity.FindAsync(DocumentNumber);

                if (response != null)
                {
                    response.Age = edad;
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


        public async Task<bool> EditarPhoneCliente(Guid DocumentNumber, string num)
        {
            try
            {
                var response = await _context.CustomerEntity.FindAsync(DocumentNumber);

                if (response != null)
                {
                    response.PhoneNumber = num;
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



        public async Task<bool> EditarEmailCliente(Guid DocumentNumber, string email)
        {
            try
            {
                var response = await _context.CustomerEntity.FindAsync(DocumentNumber);

                if (response != null)
                {
                    response.Email = email;
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


        public async Task<bool> EditarEstadoCliente(Guid DocumentNumber, bool estado)
        {
            try
            {
                var response = await _context.CustomerEntity.FindAsync(DocumentNumber);

                if (response != null)
                {
                    response.Estado = estado;
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
