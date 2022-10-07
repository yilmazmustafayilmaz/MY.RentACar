using Core.Utilies.Results;
using Entities.Concreate;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IResult Add(Customer customer);
        IResult Update(Customer customer);
        IResult Delete(Customer customer);
        IDataResult<Customer> GetbyId(int id);
        IDataResult<List<Customer>> GetAll();
    }
}
