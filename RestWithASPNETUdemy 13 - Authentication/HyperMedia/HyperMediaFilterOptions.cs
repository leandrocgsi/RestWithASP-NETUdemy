using System.Collections.Generic;

namespace HyperMedia
{
    public class HyperMediaFilterOptions
    {
        public List<IResponseEnricher> ObjectContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
    }
}