namespace Api.Features.Values.Create
{
    using System.Collections.Generic;

    public class CreateValuesResponse : BaseHateoasResponse
    {
        public CreateValuesResponse(int id, string value, IEnumerable<Link> links)
            : base(links)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; }
        public string Value { get; }
    }
}