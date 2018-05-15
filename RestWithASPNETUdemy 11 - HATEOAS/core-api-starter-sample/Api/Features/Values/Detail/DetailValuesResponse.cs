namespace Api.Features.Values.Detail
{
    using System.Collections.Generic;

    public class DetailValuesResponse : BaseHateoasResponse
    {
        public DetailValuesResponse(string value, IEnumerable<Link> links)
            : base(links)
        {
            Value = value;
        }

        public string Value { get; }
    }
}