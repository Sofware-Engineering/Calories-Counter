using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaloriesCounter.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
    }
}
