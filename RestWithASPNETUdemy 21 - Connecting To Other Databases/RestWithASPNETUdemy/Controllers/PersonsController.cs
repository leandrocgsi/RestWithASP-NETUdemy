using DomainModel.Model;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Business;
namespace RestWithASPNETUdemy.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/persons/v1/ */
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class PersonsController : Controller
    {
        private IPersonBusiness _personBusiness;

        public PersonsController(IPersonBusiness personBusiness)
        {
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personBusiness.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new  ObjectResult(_personBusiness.Create(person));
        }

        [HttpPut]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            var updatedPerson = _personBusiness.Update(person);
            if (updatedPerson == null) return BadRequest();
            return new ObjectResult(updatedPerson);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _personBusiness.Delete(id);
            return NoContent();
        }
    }
}
