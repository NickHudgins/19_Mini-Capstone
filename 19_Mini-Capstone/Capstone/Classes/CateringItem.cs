using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class CateringItem 
    {
        // This class should contain the definition for one catering item

        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public string ItemClass { get; set; }
        public string ItemQty { get; set; } = "50";




        

    }
}
