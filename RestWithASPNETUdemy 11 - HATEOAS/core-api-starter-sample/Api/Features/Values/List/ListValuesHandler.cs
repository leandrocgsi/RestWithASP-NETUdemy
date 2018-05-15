namespace Api.Features.Values.List
{
    using System.Collections.Generic;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class ListValuesHandler : IRequestHandler<ListValuesRequest, ListValuesResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public ListValuesHandler(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public ListValuesResponse Handle(ListValuesRequest message)
        {
            return new ListValuesResponse(new[]
            {
                new ListValuesResponseItem(1, "value1", CreateValueLinks(1)),
                new ListValuesResponseItem(2, "value2", CreateValueLinks(2)),
                new ListValuesResponseItem(3, "value3", CreateValueLinks(3)),
                new ListValuesResponseItem(4, "value4", CreateValueLinks(4)),
                new ListValuesResponseItem(5, "value5", CreateValueLinks(5))
            }, CreateLinks());
        }

        private IEnumerable<Link> CreateLinks()
        {
            return new[]
            {
                _urlHelper.CreateCreateValuesLinkForCollection()
            };
        }

        private IEnumerable<Link> CreateValueLinks(int id)
        {
            var links = new[]
            {
                _urlHelper.CreateDetailValuesLink(id),
                _urlHelper.CreateEditValuesLink(id),
                _urlHelper.CreateDeleteValuesLink(id)
            };
            return links;
        }
    }
}