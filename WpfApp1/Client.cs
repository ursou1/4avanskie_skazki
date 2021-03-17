using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1
{
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string CarNumber { get; set; }
        public string CarBrand { get; set; }
        public List<DateTime> VisitLog { get; set; } = new List<DateTime>();

        public string Name { get => $"{LastName} {FirstName} {FatherName}"; }
    }
}
