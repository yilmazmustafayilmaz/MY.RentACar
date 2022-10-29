using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, DatabaseContext>, ICarDal
    {
        public List<Car> GetCarByBrandId(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Cars.Where(x => x.BrandId == id).ToList();
            }
        }

        public List<Car> GetCarByColorId(int id)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                return context.Cars.Where(x => x.ColorId == id).ToList();
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from car in context.Cars
                             join brand in context.Brands on car.BrandId equals brand.Id
                             join color in context.Colors on car.ColorId equals color.Id
                             select new CarDetailDto
                             {
                                 BrandName = brand.Name,
                                 CarName = car.Description,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice
                             };
                return result.ToList();
            }
        }
    }
}
