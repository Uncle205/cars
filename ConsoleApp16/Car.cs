using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
   
        public enum CarType
        {
            passenger,
            sport,
            truck,
            bus
        }
        public class Car
        {
            private Random random = new Random(DateTime.Now.Millisecond);
            public int Speed { get; set; }
            public CarType Type { get; set; }
            public string Name { get; set; }
            public delegate void Move(string message, bool isFinished);
            public event Move Go;
            private int way;
            public int Way
            {
                get { return way; }
                set
                {
                    way = value;
                    if (value <= 0)
                    {
                        Go?.Invoke($"{this.Name} финишировал", true);
                    }
                    else
                    {
                        Go?.Invoke($"{this.Name} осталось {value}", false);
                    }
                }
            }
            public void Moving()
            {
                Way -= random.Next(0, 10);
            }
            public Car(CarType type, string name)
            {
                Name = name;
                Type = type;
            }
        }
    
}
