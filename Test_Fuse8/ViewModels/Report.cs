using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Test_Fuse8.ViewModels
{
    public class Report
    {
        public int Number { get; set; }
        public DateTime? OrderDate { get; set; }
        public int Article { get; set; }
        public string Name { get; set; }
        public short? Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}