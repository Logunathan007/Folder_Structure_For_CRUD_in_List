using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS.Domain.Entities
{
    public class StudentDetail
    {
        [Key]
        public Guid StudentId { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public Student student { get; set; }
    }
}
