using DBCreation.Application.Models;
using DBCreation.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBCreation.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly IOperations operations;
        public StudentApiController(IOperations _operations)
        {
            Console.WriteLine("DMLOperations is worked");
            operations = _operations;
        }
        // GET: api/<StudentApiController>
        [HttpGet]
        public ActionResult<List<StudentDTO>> Get()
        {
            List<StudentDTO> stdDTO = operations.GetAll();
            if(stdDTO == null)
            {
                return BadRequest();
            }
            return Ok(stdDTO);
        }

        // GET api/<StudentApiController>/5
        [HttpGet("{id}")]
        public ActionResult<StudentDTO> Get(int id)
        {
            StudentDTO stdDTO = operations.GetById(id);
            if (stdDTO == null)
            {
                return BadRequest();
            }
            return Ok(stdDTO);
        }

        // POST api/<StudentApiController>
        [HttpPost]
        public ActionResult<StudentDTO> Post([FromBody] StudentDTO value)
        {
            StudentDTO stdDTO = operations.AddNew(value);
            if (stdDTO == null)
            {
                return BadRequest();
            }
            return Ok(stdDTO);
        }

        // PUT api/<StudentApiController>/5
        [HttpPut("{id}")]
        public ActionResult<StudentDTO> Put(int id, [FromBody] StudentDTO value)
        {
            StudentDTO stdDTO = operations.UpdateById(id,value);
            if (stdDTO == null)
            {
                return BadRequest();
            }
            return Ok(stdDTO);
        }

        // DELETE api/<StudentApiController>/5
        [HttpDelete("{id}")]
        public ActionResult<StudentDTO> Delete(int id)
        {
            StudentDTO stdDTO = operations.DeleteById(id);
            if (stdDTO == null)
            {
                return BadRequest();
            }
            return Ok(stdDTO);
        }
    }
}
