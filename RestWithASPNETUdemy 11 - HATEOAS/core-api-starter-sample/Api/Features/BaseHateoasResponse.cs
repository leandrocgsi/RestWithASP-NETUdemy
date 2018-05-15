namespace Api.Features
{
    using System.Collections.Generic;

    public class BaseHateoasResponse
    {
        public BaseHateoasResponse(IEnumerable<Link> links)
        {
            Links = links;
        }

        public IEnumerable<Link> Links { get; }
    }
}