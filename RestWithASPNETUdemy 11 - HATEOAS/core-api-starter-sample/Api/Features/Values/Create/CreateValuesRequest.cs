namespace Api.Features.Values.Create
{
    using MediatR;

    public class CreateValuesRequest : IRequest<CreateValuesResponse>
    {
        public string Value { get; set; }
    }
}