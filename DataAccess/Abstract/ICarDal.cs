using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAllCars();
        List<Brand> GetAllBrands();
        List<Color> GetAllColors();
        Car GetById(int id);
        void CarAdd(Car car);
        void CarUpdate(Car car);
        void CarDelete(Car car);
    }
}
