namespace Api.Features.Values.Detail
{
    using System.Collections.Generic;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class DetailValuesHandler : IRequestHandler<DetailValuesRequest, DetailValuesResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public DetailValuesHandler(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public DetailValuesResponse Handle(DetailValuesRequest message)
        {
            if (message.Id > 5)
                return null;
            return new DetailValuesResponse($"value{message.Id}", CreateLinks(message.Id));
        }

        private IEnumerable<Link> CreateLinks(int id)
        {
            var links = new[]
            {
                _urlHelper.CreateListValuesLink(),
                _urlHelper.CreateEditValuesLink(id),
                _urlHelper.CreateDeleteValuesLink(id),
                _urlHelper.CreateCreateValuesLinkForValue()
            };
            return links;
        }
    }
}