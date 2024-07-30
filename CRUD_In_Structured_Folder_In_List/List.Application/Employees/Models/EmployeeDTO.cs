using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List.Application.Employees.Models;

public class EmployeeDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Designation { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}
