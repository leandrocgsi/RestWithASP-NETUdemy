namespace Api.Features.Values.Edit
{
    using System.Collections.Generic;

    public class EditValuesResponse : BaseHateoasResponse
    {
        public EditValuesResponse(int id, string value, IEnumerable<Link> links)
            : base(links)
        {
            Id = id;
            Value = value;
        }

        public int Id { get; }
        public string Value { get; }
    }
}