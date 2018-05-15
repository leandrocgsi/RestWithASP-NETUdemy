namespace Api.Features.Values.Create
{
    using System;
    using System.Collections.Generic;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class CreateValuesHandler : IRequestHandler<CreateValuesRequest, CreateValuesResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public CreateValuesHandler(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public CreateValuesResponse Handle(CreateValuesRequest message)
        {
            //Create domain object

            var randomId = new Random().Next(6, 100);
            return new CreateValuesResponse(randomId, message.Value, CreateLinks(randomId));
        }

        private IEnumerable<Link> CreateLinks(int id)
        {
            var links = new[]
            {
                _urlHelper.CreateListValuesLink(),
                _urlHelper.CreateDetailValuesLink(id),
                _urlHelper.CreateEditValuesLink(id),
                _urlHelper.CreateDeleteValuesLink(id)
            };
            return links;
        }
    }
}