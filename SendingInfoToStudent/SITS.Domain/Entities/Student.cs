using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS.Domain.Entities
{
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string Name { get; set; }
        public StudentDetail studentDetails { get; set; }
    }
}
