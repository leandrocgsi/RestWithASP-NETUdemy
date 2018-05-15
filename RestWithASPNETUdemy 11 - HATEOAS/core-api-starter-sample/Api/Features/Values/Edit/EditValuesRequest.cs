namespace Api.Features.Values.Edit
{
    using MediatR;

    public class EditValuesRequest : IRequest<EditValuesResponse>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}