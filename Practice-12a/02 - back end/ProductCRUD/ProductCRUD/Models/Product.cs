using System;
using System.Collections.Generic;

#nullable disable

namespace ProductCRUD.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Cost { get; set; }
    }
}
