using Microsoft.AspNetCore.Mvc;
using SITS.Application.Models;
using SITS.Application.Operations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SITS.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        IRequestAndResponse _res;

        public ApiController(IRequestAndResponse res)
        {
            _res = res;
        }

        [HttpGet]
        public IEnumerable<StudentCombained> Get()
        {
            return _res.getAllData();
        }

        [HttpPost]
        public StudentCombained Post([FromBody] StudentCombained value)
        {
            return _res.AddNewData(value);
        }

       
    }
}
