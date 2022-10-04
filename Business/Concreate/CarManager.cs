using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;

namespace Business.Concreate
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length > 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else if (car.Description.Length > 2 && car.DailyPrice <= 0)
            {
                Console.WriteLine("Araba Fiyatı Sıfırdan Küçük Olamaz: " + car.DailyPrice);
            }
            else if (car.Description.Length < 2 && car.DailyPrice > 0)
            {
                Console.WriteLine("Araba İsmi En Az İki Kelime Olmalıdır: " + car.Description);
            }

            else
            {
                Console.WriteLine("Araba marka ismi minimum 2 karakter olmalı, günlük fiyat ise 0'dan büyük olmalıdır");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
