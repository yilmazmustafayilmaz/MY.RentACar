using Core.Utilies.Results;
using Entities.Concreate;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
        IDataResult<User> GetbyId(int userId);
        IDataResult<List<User>> GetAll();
    }
}
