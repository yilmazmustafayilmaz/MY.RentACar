using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, DatabaseContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (DatabaseContext context = new DatabaseContext())
            {
                var result = from Oc in context.OperationClaims
                             join Uoc in context.UserOperationClaims
                             on Oc.Id equals Uoc.Id
                             where Uoc.Id == user.Id
                             select new OperationClaim { Id = Oc.Id, Name = Oc.Name };
                return result.ToList();
            }

        }
    }
}
