using System;
using System.Collections.Generic;


namespace SalesWebMvc3.Models.ModelsView
{
    public class SellerFormViewModel
    {
        public Saller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
