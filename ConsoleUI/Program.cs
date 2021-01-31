using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Car addedCar = new Car();
            Car updatedCar = new Car();
            Car deletedCar = new Car();
            CarManager carManager = new CarManager(new InMemoryCarDal());
            Console.WriteLine("----------Listeleme---------");
            foreach (var item in carManager.GetAllCars())
            {
                var brand = carManager.GetAllBrands().SingleOrDefault(b => b.BrandId == item.BrandId);
                var color = carManager.GetAllColors().SingleOrDefault(c => c.ColorId == item.ColorId);
                Console.WriteLine(item.Description + " " + item.ModelYear + " Model " + color.ColorName + " bir " + brand.BrandName + " Günlük kira: " + item.DailyPrice + "TL");
            }
            Console.WriteLine();
            Console.WriteLine("---------Ekleme--------");
            addedCar.CarId = 6;
            addedCar.BrandId = 3;
            addedCar.ColorId = 3;
            addedCar.DailyPrice = 250;
            addedCar.Description = "Miss gibi..";
            addedCar.ModelYear = "2077";
            carManager.CarAdd(addedCar);

            foreach (var item in carManager.GetAllCars())
            {
                var brand = carManager.GetAllBrands().SingleOrDefault(b => b.BrandId == item.BrandId);
                var color = carManager.GetAllColors().SingleOrDefault(c => c.ColorId == item.ColorId);
                Console.WriteLine(item.Description + " " + item.ModelYear + " Model " + color.ColorName + " bir " + brand.BrandName + " Günlük kira: " + item.DailyPrice + "TL");
            }

            Console.WriteLine();
            Console.WriteLine("---------Güncelleme--------");
            updatedCar.CarId = 2;
            updatedCar.BrandId = 2;
            updatedCar.ColorId = 3;
            updatedCar.DailyPrice = 50;
            updatedCar.Description = "Biraz döküntü..";
            updatedCar.ModelYear = "1984";
            carManager.CarUpdate(updatedCar);
            Console.WriteLine();
            foreach (var item in carManager.GetAllCars())
            {
                var brand = carManager.GetAllBrands().SingleOrDefault(b => b.BrandId == item.BrandId);
                var color = carManager.GetAllColors().SingleOrDefault(c => c.ColorId == item.ColorId);
                Console.WriteLine(item.Description + " " + item.ModelYear + " Model " + color.ColorName + " bir " + brand.BrandName + " Günlük kira: " + item.DailyPrice + "TL");
            }

            Console.WriteLine();
            Console.WriteLine("---------Silme--------");
            deletedCar.CarId = 4;
            carManager.CarDelete(deletedCar);

            foreach (var item in carManager.GetAllCars())
            {
                var brand = carManager.GetAllBrands().SingleOrDefault(b => b.BrandId == item.BrandId);
                var color = carManager.GetAllColors().SingleOrDefault(c => c.ColorId == item.ColorId);
                Console.WriteLine(item.Description + " " + item.ModelYear + " Model " + color.ColorName + " bir " + brand.BrandName + " Günlük kira: " + item.DailyPrice + "TL");
            }

            Console.WriteLine();
            Console.WriteLine("--------Ver ID'yi Al Arabayı-------");
            Console.WriteLine();
            var result = carManager.GetById(1);
            try
            {
                //Burada sistem veriyi getirebilmesi için ID ye sahip olması gerekiyor.
                //Eğer verdiğiniz ID ye sahip bir veri yoksa sistem kırılacağından try-catch içine aldım.
                //Fakat sistem hatayı alınca durduruyor programa başlatma tuşuna tekrar basarsanız sorunsuz devam eder program :)
                var brand1 = carManager.GetAllBrands().SingleOrDefault(b => b.BrandId == result.BrandId);
                var color1 = carManager.GetAllColors().SingleOrDefault(c => c.ColorId == result.ColorId);
                Console.WriteLine(result.Description + " " + result.ModelYear + " Model " + color1.ColorName + " bir " + brand1.BrandName + " Günlük kira: " + result.DailyPrice + "TL");

            }
            catch
            {
                Console.WriteLine("Sistem veirlen ID numarasına sahip ögeyi bulamadı!");
            }

        }
    }
}
