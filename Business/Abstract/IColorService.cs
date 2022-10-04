using Entities.Concreate;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetCarsByColorId(int id);
        List<Color> GetAll();
        void Add(Color color);
    }
}
