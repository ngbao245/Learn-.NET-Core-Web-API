using CRMCar.Data;
using Microsoft.EntityFrameworkCore;

namespace CRMCar.Repository
{
    public interface ICarRepo
    {
        List<Car> GetAllCars();
        int AddNewCar(Car carEntity);
        Car? getSingleCar(int id);
        int UpdateCar(Car carEntity, int id);
        int DeleteCar(int id);
    }
    public class CarRepo : ICarRepo
    {
        //private DbSet<Car> _dbSet;
        public CarRepo()
        {

        }

        public List<Car>? GetAllCars()
        {
            //var cars = _dbSet.ToList();
            //return cars;
            using (var context = new AppDbContext())
            {
                var cars = context.Set<Car>().ToList();
                return cars;
            }
        }

        public Car? getSingleCar(int id)
        {
            using (var context = new AppDbContext())
            {
                var car = context.Set<Car>().Where(_ => _.Id == id).SingleOrDefault();
                return car;
            }
        }

        public int AddNewCar(Car carEntity)
        {
            using (var context = new AppDbContext())
            {
                var user = context.Set<User>().Where(_ => _.Id == carEntity.UserId).FirstOrDefault();
                if (user == null)
                {
                    return 0;
                }
                context.Set<Car>().Add(carEntity);
                return context.SaveChanges();
            }
        }

        public int UpdateCar(Car carEntity, int id)
        {
            using (var context = new AppDbContext())
            {
                var car = getSingleCar(id);
                if (car == null)
                {
                    return 0;
                }
                context.Set<Car>().Update(carEntity);
                return context.SaveChanges();
            }
        }

        public int DeleteCar(int id)
        {
            using (var context = new AppDbContext())
            {
                var car = getSingleCar(id);
                if (car == null)
                {
                    return 0;
                }
                context.Set<Car>().Remove(car);
                return context.SaveChanges();
            }
        }
    }
}