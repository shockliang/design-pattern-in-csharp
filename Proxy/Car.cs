using System;
using static System.Console;

namespace Proxy
{
    public interface ICar
    {
        void Drive();
    }

    public class Car : ICar
    {
        public void Drive()
        {
            WriteLine("Car is being driven");
        }
    }

    public class Driver
    {
        public Driver(int age) => Age = age;

        public int Age { get; set; }
    }

    public class CarProxy : ICar
    {
        private readonly Driver driver;
        private Car car = new Car();

        public CarProxy(Driver driver)
        {
            this.driver = driver;
        }

        public void Drive()
        {
            if (driver.Age >= 18)
            {
                car.Drive();
            }
            else
            {
                WriteLine("Too yound");
            }
        }
    }
}