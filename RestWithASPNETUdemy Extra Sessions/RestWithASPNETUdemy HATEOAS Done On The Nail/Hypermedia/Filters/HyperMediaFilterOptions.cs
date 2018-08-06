using System.Collections.Generic;
using Hypermedia.Abstract;

namespace Hypermedia.Filters
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ObjectContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}