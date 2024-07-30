
using List.Persistence.Contexts;
using Microsoft.AspNetCore.Mvc;

using List.Application.Employees.Services;
using List.Application.Employees.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace List.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {
        LOEs loe;
        IOperations operations;
        void print(List<EmployeeDTO> refer)
        {
            refer.ForEach(e => Console.WriteLine(e.Name+" "+e.Email));
        }

        public APIController(LOEs _loe, IOperations operation)
        {
            loe = _loe;
            this.operations = operation;
        }
        // GET: api/<APIController>
        [HttpGet]
        public ActionResult<List<EmployeeDTO>> Get()
        {
            return Ok(operations.GetAll());
        }

        // GET api/<APIController>/5
        [HttpGet("{id}")]
        public ActionResult<EmployeeDTO> Get(Guid id)
        {
            EmployeeDTO eDTO = operations.GetById(id);
            if (eDTO == null)
            {
                return BadRequest(null);
            }
            return Ok(eDTO);
        }

        // POST api/<APIController>
        [HttpPost]
        public ActionResult Post([FromBody] EmployeeDTO employeeDTO)
        {
            operations.AddNew(employeeDTO);
            return Ok();
        }

        // PUT api/<APIController>/5
        [HttpPut("{id}")]
        public ActionResult<EmployeeDTO> Put(Guid id, [FromBody] EmployeeDTO employeeDTO)
        {
            employeeDTO.Id = id;
            if (operations.UpdateById(id,employeeDTO) != null)
            {
                return Ok(employeeDTO);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<APIController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            if (operations.DeleteById(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
