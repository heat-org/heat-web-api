using System;
using System.Collections.Generic;
using System.Text;

namespace Heat.Application
{
    public class ReportDTO
    {
        public int ReviewID { get; set; }
        public string User { get; set; }
        public int TypeID { get; set; }
        public string Text { get; set; }
    }
}