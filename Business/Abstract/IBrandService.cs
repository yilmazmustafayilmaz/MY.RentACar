using Entities.Concreate;

namespace Business.Abstract
{
    public interface IBrandService
    {
        List<Brand> GetAll();
        List<Brand> GetCarsByBrandId(int id);
    }
}
