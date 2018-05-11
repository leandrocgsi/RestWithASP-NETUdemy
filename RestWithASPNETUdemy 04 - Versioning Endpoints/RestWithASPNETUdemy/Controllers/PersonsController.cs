using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Services;
namespace RestWithASPNETUdemy.Controllers
{

    /* Mapeia as requisições de http://localhost:{porta}/api/persons/v1/
    Por padrão o ASP.NET Core mapeia todas as classes que extendem Controller
    pegando a primeira parte do nome da classe em lower case [Person]Controller
    e expõe como endpoint REST
    */
    [Route("api/[controller]")]
    public class PersonsController : Controller
    {
        //Declaração do serviço usado
        private IPersonService _personService;

        /* Injeção de uma instancia de IPersonService ao criar
        uma instancia de PersonController */
        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/persons/v1/
        //Get sem parâmetros para o FindAll --> Busca Todos
        [HttpGet("v1")]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        //Mapeia as requisições GET para http://localhost:{porta}/api/persons/v1/{id}
        //recebendo um ID como no Path da requisição
        //Get com parâmetros para o FindById --> Busca Por ID
        [HttpGet("v1/{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        //Mapeia as requisições POST para http://localhost:{porta}/api/persons/v1/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPost("v1")]
        public IActionResult Post([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new  ObjectResult(_personService.Create(person));
        }

        //Mapeia as requisições PUT para http://localhost:{porta}/api/persons/v1/
        //O [FromBody] consome o Objeto JSON enviado no corpo da requisição
        [HttpPut("v1/{id}")]
        public IActionResult Put([FromBody]Person person)
        {
            if (person == null) return BadRequest();
            return new ObjectResult(_personService.Update(person));
        }


        //Mapeia as requisições DELETE para http://localhost:{porta}/api/persons/v1/{id}
        //recebendo um ID como no Path da requisição
        [HttpDelete("v1/{id}")]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
