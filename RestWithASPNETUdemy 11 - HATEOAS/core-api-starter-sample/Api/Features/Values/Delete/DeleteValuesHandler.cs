namespace Api.Features.Values.Delete
{
    using MediatR;

    public class DeleteValuesHandler : IRequestHandler<DeleteValuesRequest>
    {
        public void Handle(DeleteValuesRequest message)
        {
            //Delete domain object or ignore if object does not exist
            //Alternatively: create validator and return NotFound
        }
    }
}