using Microsoft.AspNetCore.Mvc;
using RequestCheck.Data;

namespace RequestCheck.Controllers
{
    [ApiController]
    [Route("api/sample")]
    public class SampleRequest : ControllerBase
    {
        public static Operations operation;
        static SampleRequest() { 
            EmployeeList list = new EmployeeList();
            operation = new Operations();
            List<Employee> employees = new List<Employee>
            {
                new Employee{Id=1,Name="Logu",Designation="JSD"},
                new Employee{Id=2,Name="Aswin",Designation="JSD"},
                new Employee{Id=3,Name="K7",Designation="SDE"},
            };
            operation.AddEmploees(employees);
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<List<Employee>> Get()
        {
            return Ok(operation.GetAllEmployees());
        }
        [HttpGet("id")]
        [ProducesResponseType(400)]
        public ActionResult Get(int id)
        {
            return Ok(operation.GetEmployee(id));
        }
        [HttpPost]
        public ActionResult<List<Employee>> Post([FromBody] Employee employee)
        {
            List<Employee> list = operation.GetAllEmployees();
            if (employee == null) {
                return BadRequest(list);
            }
            if(operation.GetEmployee(employee.Id) != null)
            {
                Console.WriteLine("worked");
                return Conflict(list);
            }
            return Ok(operation.AddEmploee(employee));
        }

        [HttpDelete]
        public ActionResult<Employee> DeleteRequest([FromBody] int id) {
            Employee obj = operation.GetEmployee(id);
            if (obj == null)
            {
                return NotFound();
            }
            operation.GetAllEmployees().Remove(obj);
            return Ok(operation.GetAllEmployees());
        }

        [HttpPut("id")]
        public ActionResult<List<Employee>> PutRequest(int id,[FromBody] string Name)
        {
            Employee obj = operation.GetEmployee(id);
            obj.Name = Name;
            return Ok(operation.GetAllEmployees());
        }

    }
}
