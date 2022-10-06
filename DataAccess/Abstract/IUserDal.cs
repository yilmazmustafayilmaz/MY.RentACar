using Core.DataAccess;
using Entities.Concreate;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
