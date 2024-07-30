using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using List.Domain.Entities;

namespace List.Persistence.Contexts
{
    public interface LOEs
    {
        List<Employee> getListOfEmployees();
    }

    public class LIstOfEmployees : LOEs
    {
        public readonly List<Employee> list;
        public LIstOfEmployees()
        {
            list = new List<Employee>()
            {
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Logunathan J",
                    Email = "Logu@gmail.com",
                    Designation = "JSD",
                    Phone = "987841934"
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Aswin E",
                    Email = "Aswindotcom@gmail.com",
                    Designation = "JSD",
                    Phone = "987987979"
                },
                new Employee()
                {
                    Id = Guid.NewGuid(),
                    Name = "Kaviyarasan D",
                    Email = "Kavi@gmail.com",
                    Designation = "JSD",
                    Phone = "2342341934"
                }

            };
        }
        
        public List<Employee> getListOfEmployees()
        {
            return list;
        }
    }
}
