namespace Api.Features.Values.Delete
{
    using MediatR;

    public class DeleteValuesRequest : IRequest
    {
        public int Id { get; set; }
    }
}