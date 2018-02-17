using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kargo
{
    public static class Program
    {
        public delegate void SpeedHandler(string x,int y);

        class CargoVehicle
        {
            private string plaka;
            private int speed;

            public string Plaka
            {
                get
                {
                    return plaka;
                }
                set
                {
                    plaka = value;
                }
            }

            public int Speed
            {
                get
                {
                    return speed;
                }

                set
                {
                    if (Speed > 110)
                    {
                        speed = value;
                        SpeedExceeded(Plaka, Speed);
                    }else
                        speed = value;
                }
            }

            public CargoVehicle() {}

            public CargoVehicle(string plaka)
            {
                Plaka = plaka;
            }

            public event SpeedHandler SpeedExceeded;
        }

        static void Main(string[] args)
        {
            CargoVehicle kargo_aracı1 = new CargoVehicle("42SU1975");
            CargoVehicle kargo_aracı2 = new CargoVehicle("10BA1997");

            kargo_aracı1.SpeedExceeded += new SpeedHandler(kargo_aracı_SpeedExceeded);
            kargo_aracı2.SpeedExceeded += new SpeedHandler(kargo_aracı_SpeedExceeded);

            for (byte i = 80; i < 130; i += 5)
            {
                kargo_aracı1.Speed = i;
                kargo_aracı2.Speed = (i + 5);

                Console.WriteLine(kargo_aracı1.Plaka + " plakalı aracın hızı = " + kargo_aracı1.Speed);
                Console.WriteLine(kargo_aracı2.Plaka + " plakalı aracın hızı = " + kargo_aracı2.Speed);

                System.Threading.Thread.Sleep(1000);
            }
            Console.ReadKey();
        }

        public static void kargo_aracı_SpeedExceeded(string Plaka, int Speed)
        {
             DateTime tarih = DateTime.Now;
             Console.WriteLine("Alarm "+ Plaka + " Plakalı kargo aracı hız limitini aştı "+ tarih + " anindaki hizi = "+ Speed);
        }
    }
}

