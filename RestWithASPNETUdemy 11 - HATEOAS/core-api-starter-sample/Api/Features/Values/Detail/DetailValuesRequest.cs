namespace Api.Features.Values.Detail
{
    using MediatR;

    public class DetailValuesRequest : IRequest<DetailValuesResponse>
    {
        public int Id { get; set; }
    }
}