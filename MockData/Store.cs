using System;
using System.Collections.Generic;
using System.Text;

namespace MockData
{
    public static class Store
    {

        public static IAnimal OneObj()
        {
            return new Dog { Name = "Dog" };
        }
        public static IEnumerable<IAnimal> AnyObj()
        {
            var list = new List<IAnimal>
            {
                new Dog { Name = "Dog1" },
                new Dog { Name = "Dog2" },
                new Dog { Name = "Dog3" },
                new Bird { Name = "Bird1" },
                new Bird { Name = "Bird2" }
            };
            return list;
        }
    }
}
