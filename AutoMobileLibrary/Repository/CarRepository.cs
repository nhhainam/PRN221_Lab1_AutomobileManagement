using AutoMobileLibrary.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMobileLibrary.Repository
{
    public class CarRepository : ICarRepository
    {
        public void DeleteCar(Car car)
        {
            CarManagement.Instance.Remove(car);
        }

        public Car GetCarByID(int carId)
        {
            return CarManagement.Instance.getCarByID(carId);
        }

        public IEnumerable<Car> GetCars()
        {
            return CarManagement.Instance.getCarList();
        }

        public void InsertCar(Car car)
        {
            CarManagement.Instance.AddNew(car);
        }

        public void UpdateCar(Car car)
        {
            CarManagement.Instance.Update(car);
        }
    }
}
