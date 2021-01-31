using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void CarAdd(Car car)
        {
            //İş Kodlar+Kurallar
            _carDal.CarAdd(car);
        }

        public void CarDelete(Car car)
        {
            //İş Kodlar+Kurallar
            _carDal.CarDelete(car);
        }

        public void CarUpdate(Car car)
        {
            var result = _carDal.GetAllCars().SingleOrDefault(c=>c.CarId == car.CarId);
            if (result != null)
            {
                _carDal.CarUpdate(car);
            }
            else
            {
                Console.WriteLine("Güncelleme işleminde beklenmedik bir sorunla karşılaşıldı!");
            }
            
        }

        public List<Brand> GetAllBrands()
        {
            return _carDal.GetAllBrands();
        }

        public List<Car> GetAllCars()
        {
            //İş Kodlar+Kurallar
            return _carDal.GetAllCars();
        }

        public List<Color> GetAllColors()
        {
            return _carDal.GetAllColors();
        }

        public Car GetById(int id)
        {
            
            
            return _carDal.GetById(id);
        }
    }
}
