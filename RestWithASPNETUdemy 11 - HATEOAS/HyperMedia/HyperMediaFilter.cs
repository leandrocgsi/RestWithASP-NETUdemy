using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HyperMedia
{
    public class HyperMediaFilter : ResultFilterAttribute
    {
        private readonly HyperMediaFilterOptions _hyperMediaFilterOptions;

        public HyperMediaFilter(HyperMediaFilterOptions hyperMediaFilterOptions)
        {
            _hyperMediaFilterOptions = hyperMediaFilterOptions;
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            TryEnrichResult(context);
            base.OnResultExecuting(context);
        }

        private void TryEnrichResult(ResultExecutingContext context)
        {
            var result = context.Result;

            if (result is OkObjectResult okObjectResult)
            {
                /*if (okObjectResult.Value is ISupportsHyperMedia model)
                {*/
                    var enricher = _hyperMediaFilterOptions.ObjectContentResponseEnricherList.FirstOrDefault(x => x.CanEnrich(context));
                    if (enricher != null) Task.FromResult(enricher.Enrich(context));
                /*} else
                {
                    var o = okObjectResult as OkObjectResult;
                    List<Object> collection = o.Value as List<Object>;
                    foreach (object element in collection)
                    {
                        if (element is ISupportsHyperMedia item)
                        {
                            var enricher = _hyperMediaFilterOptions.ObjectContentResponseEnricherList.FirstOrDefault(x => x.CanEnrich(context));
                            if (enricher != null) Task.FromResult(enricher.Enrich(context));
                        }
                    }
                }*/
                
            }
        }

        bool IsCollectionType(Type type)
        {
            return (type.GetInterface(nameof(ICollection)) != null);
        }
    }
}