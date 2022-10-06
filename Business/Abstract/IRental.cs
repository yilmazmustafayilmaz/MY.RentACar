using Core.Utilies.Results;
using Entities.Concreate;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult Add(Rental rental);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
        IDataResult<Rental> GetbyId(int rentalId);
        IDataResult<List<Rental>> GetAll();
    }
}
