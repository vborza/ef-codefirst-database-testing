using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace Dal.DataModel
{
    public class Employee
    {
        public int Id { get; set; }

        [MaxLength(30), Index(IsUnique = true)]
        public string IdCardNumber { get; set; }

        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        public virtual ICollection<BusinessTrip> BusinessTrips { get; set; } 
    }
}
