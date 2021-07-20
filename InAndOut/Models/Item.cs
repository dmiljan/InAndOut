using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //[Key]

namespace InAndOut.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        public string Borrower { get; set; }
    }
}
