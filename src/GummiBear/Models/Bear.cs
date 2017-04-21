using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GummiBear.Models
{
    [Table("Bears")]
    public class Bear
    {
        [Key]
        public int BearId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public string Country { get; set; }
    }
}
