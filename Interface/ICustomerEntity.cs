using Examen.Dtos;
using Examen.Models;

namespace Examen.Interface
{
    public interface ICustomerEntity
    {
        public Task<bool> InsertarCustomer(CustomerEntityDto customerEntityDto);
        public Task<bool> EditarNombreCliente(Guid DocumentNumber, string nombre);
        public  Task<bool> EditarApellidoCliente(Guid DocumentNumber, string apellido);
        public  Task<bool> EditarEdadCliente(Guid DocumentNumber, int edad);
        public  Task<bool> EditarPhoneCliente(Guid DocumentNumber, string num);
        public  Task<bool> EditarEmailCliente(Guid DocumentNumber, string email);
        public  Task<bool> EditarEstadoCliente(Guid DocumentNumber, bool estado);


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
            }catch (Exception)
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
