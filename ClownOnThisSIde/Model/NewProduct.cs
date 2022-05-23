using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClownOnThisSIde.Model
{
    class NewProduct
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public int Article { get; set; }
        public double? PwNumber { get; set; }
        public int? PType { get; set; }
    }
}
