using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        List<Brand> _brands;
        List<Color> _colors;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=450,ModelYear="2020",Description="Kalpleri kazanmaya hazır."},
                new Car{CarId=2,BrandId=2,ColorId=3,DailyPrice=210,ModelYear="2019",Description="Güzel bir yol aracı."},
                new Car{CarId=3,BrandId=3,ColorId=2,DailyPrice=320,ModelYear="2018",Description="Sessiz ekonomik elektirikli..."},
                new Car{CarId=4,BrandId=2,ColorId=1,DailyPrice=650,ModelYear="1965",Description="Mükemmel bir klasik.."},
                new Car{CarId=5,BrandId=1,ColorId=3,DailyPrice=280,ModelYear="2016",Description="Tam bir uzun yol arabası."},

            };
            _brands = new List<Brand>
            {
                new Brand{BrandId=1,BrandName="Mercedes",BrandDescription="Mercedes-Benz, 1926 yılında Karl Benz'in şirketi Benz & Cie. ve Gottlieb Daimler'in şirketi Daimler Motoren Gesellschaft'in birleşmesi sonucu kurulmuş otomotiv ve motor markası."},
                new Brand{BrandId=2,BrandName="Ford",BrandDescription="Ford Motor Company, Henry Ford tarafından Highland Park, Michigan, ABD'de 16 Haziran 1903 tarihinde kuruldu."},
                new Brand{BrandId=3,BrandName="Tesla",BrandDescription="Tesla, Inc. veya kısaca Tesla, elektrikli araç tasarlayan, üreten ve satan Palo Alto, Kaliforniya merkezli bir Amerikan şirketi."}
            };
            _colors = new List<Color>
            {
                new Color{ColorId=1,ColorName="Gümüş Gri"},
                new Color{ColorId=2,ColorName="Beyaz"},
                new Color{ColorId=3,ColorName="Siyah"},
            };


        }
        public void CarAdd(Car car)
        {
            _cars.Add(car);
        }

        public void CarDelete(Car car)
        {
            var result = _cars.SingleOrDefault(c => c.CarId == car.CarId);

            _cars.Remove(result);
        }

        public void CarUpdate(Car car)
        {
            var result = _cars.FirstOrDefault(c => c.CarId == car.CarId);
            result.BrandId = car.BrandId;
            result.ColorId = car.ColorId;
            result.DailyPrice = car.DailyPrice;
            result.Description = car.Description;
            result.ModelYear = car.ModelYear;

                

            
        }

        public List<Brand> GetAllBrands()
        {
            return _brands;
        }

        public List<Car> GetAllCars()
        {
            return _cars;
        }

        public List<Color> GetAllColors()
        {
            return _colors;
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.CarId == id);
        }
    }
}
