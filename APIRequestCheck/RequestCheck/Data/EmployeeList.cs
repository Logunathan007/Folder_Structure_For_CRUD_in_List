
using System.Collections.Generic;

namespace RequestCheck.Data
{
    public class EmployeeList
    {
        private static List<Employee> employees ;
        public EmployeeList()
        {
            employees = new List<Employee>();
        }
        public List<Employee> getListObj()
        {
            return employees;
        }
    }
}
