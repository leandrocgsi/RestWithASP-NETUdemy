using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using System;
using System.Threading.Tasks;

namespace HyperMedia
{
    /// <summary>
    /// Base class for enriching Models
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ObjectContentResponseEnricher<T> : IResponseEnricher where T : ISupportsHyperMedia
    {
        public ObjectContentResponseEnricher()
        {
        }

        /// <summary>
        /// If the types are matched then the object can be enriched with links
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public virtual bool CanEnrich(Type contentType)
        {
            return contentType == typeof(T);
        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult okObjectResult)
                return CanEnrich(okObjectResult.Value.GetType());
            return false;
        }

        public async Task Enrich(ResultExecutingContext response)
        {
            // Get the urlHelper
            var urlHelper = (new UrlHelperFactory()).GetUrlHelper(response);
            //var UrlHelper2 = new UrlHelper(response);
            if (response.Result is OkObjectResult okObjectResult)
                if (okObjectResult.Value is T model)
                    await EnrichModel(model, urlHelper);
            await Task.FromResult<object>(null);
        }
    }
}