using System;
using System.Collections.Generic;
using System.Text;

namespace Heat.Application
{
    public class ReviewDTO
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public string User { get; set; }
        public double? Rating { get; set; }
    }
}