using System;
using System.Collections.Generic;

namespace Dal.DataModel
{
    public class BusinessTrip
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public double Kms { get; set; }

        public virtual ICollection<Employee> Employees { get; set; } 
    }
}