namespace RequestCheck.Data
{
    public class Operations
    {
        EmployeeList list;
        List<Employee> employees;
        public Operations() {
            list = new EmployeeList();
            employees = list.getListObj();
        }
        public List<Employee> AddEmploee(Employee employee)
        {
            employees.Add(employee);
            Console.WriteLine("AddEmploee is Done");
            return GetAllEmployees();
        }
        public void AddEmploees(List<Employee> employee)
        {
            employees.AddRange(employee);
            Console.WriteLine("AddEmploees is Done");
            //printAll();
        }
        public List<Employee> GetAllEmployees()
        {
            return employees;
        }
        public void printAll()
        {
            GetAllEmployees().ForEach(x => Console.WriteLine(x.Id+" "+x.Name+" "+x.Designation));
        }
        public Employee GetEmployee(int id)
        {
            Console.WriteLine("GetEmployee Done");
            return employees.Find(x => x.Id == id);
        }
    }
}
