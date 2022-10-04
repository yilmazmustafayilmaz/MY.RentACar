using Entities.Concreate;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Add(Car car);
        List<CarDetailDto> GetCarDetails();
    }
}
