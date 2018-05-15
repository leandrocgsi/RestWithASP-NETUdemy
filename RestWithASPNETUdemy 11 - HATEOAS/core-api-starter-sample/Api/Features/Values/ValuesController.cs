namespace Api.Features.Values
{
    using Create;
    using Delete;
    using Detail;
    using Edit;
    using List;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class ValuesController : Controller
    {
        internal const string GetListRouteName = "Values_GetList";
        internal const string GetByIdRouteName = "Values_GetById";
        internal const string PostRouteName = "Values_Post";
        internal const string PutRouteName = "Values_Put";
        internal const string DeleteRouteName = "Values_Delete";

        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/values
        [HttpGet(Name = GetListRouteName)]
        public IActionResult Get([FromQuery] ListValuesRequest listValuesRequest)
        {
            var result = _mediator.Send(listValuesRequest ?? new ListValuesRequest()).GetAwaiter().GetResult();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id:int:min(1)}", Name = GetByIdRouteName)]
        public IActionResult Get([FromRoute] DetailValuesRequest detailValuesRequest)
        {
            var result = _mediator.Send(detailValuesRequest).GetAwaiter().GetResult();
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/values
        [HttpPost(Name = PostRouteName)]
        public IActionResult Post([FromBody] CreateValuesRequest createValuesRequest)
        {
            var result = _mediator.Send(createValuesRequest).GetAwaiter().GetResult();

            return CreatedAtRoute(GetByIdRouteName, new DetailValuesRequest {Id = result.Id}, result);
        }

        // PUT api/values/5
        [HttpPut("{id:int:min(1)}", Name = PutRouteName)]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] EditValuesRequest editValuesRequest)
        {
            editValuesRequest.Id = id;

            var result = await _mediator.Send(editValuesRequest);

            return Ok(result);
        }

        // DELETE api/values/5
        [HttpDelete("{id:int:min(1)}", Name = DeleteRouteName)]
        public async Task<IActionResult> Delete([FromRoute] DeleteValuesRequest deleteValuesRequest)
        {
            await _mediator.Send(deleteValuesRequest);

            return NoContent();
        }
    }
}