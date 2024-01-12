using CRMCar.Data;
using CRMCar.Entity;

namespace CRMCar.Repository
{
    public interface IUserRepo
    {
        List<User>? GetAllUsers();
        User? getSingleUser(int id);
        int AddNewUser(User userEntity);
        int UpdateUser(User userEntity, int id);
        int DeleteUser(int id);

    }
    public class UserRepo : IUserRepo
    {
        private AppDbContext _appDbContext = new AppDbContext();

        public UserRepo()
        {

        }

        public List<User>? GetAllUsers()
        {
            using (var context = new AppDbContext())
            {
                var users = context.Set<User>().ToList();
                return users;
            }
        }

        public User? getSingleUser(int id)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Set<User>().Where(_ => _.Id == id).SingleOrDefault();
                return user;
            }
        }

        public int AddNewUser(User userEntity)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Set<User>().Where(_ => _.Id == userEntity.Id).FirstOrDefault();
                if (user != null)
                {
                    return 0;
                }
                context.Set<User>().Add(userEntity);
                return context.SaveChanges();
            }
        }

        public int UpdateUser(User userEntity, int id)
        {
            using (var context = new AppDbContext())
            {
                var user = getSingleUser(id);
                if (user == null)
                {
                    return 0;
                }
                context.Set<User>().Update(userEntity);
                return context.SaveChanges();
            }
        }

        public int DeleteUser(int id)
        {
            using (var context = new AppDbContext())
            {
                var user = getSingleUser(id);
                if (user == null)
                {
                    return 0;
                }
                context.Set<User>().Remove(user);
                return context.SaveChanges();
            }
        }
    }
}
