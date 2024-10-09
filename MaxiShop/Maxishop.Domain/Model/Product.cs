using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxishop.Domain.Model
{
    public class Product
    {

        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public Category Category { get; set; }

        public int BrandID { get; set; }

        [ForeignKey("BrandID")]
        public Brand brand { get; set; }

        public string Name { get; set; }

        public string Specification  { get; set; }

        public double Price { get; set; }
    }
}
