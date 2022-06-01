using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication6.Models
{
    public class ProductModel
    {
         [Key]
         public int Produc_Id { get; set; }
         public string Product_Name { get; set; }
         public string Produc_Category { get; set; }
         public DateTime Produc_date { get; set; }
         public int Produc_Price { get; set; }
 

    }
}
