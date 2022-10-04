using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, DatabaseContext>, IColorDal
    {
    }
}
