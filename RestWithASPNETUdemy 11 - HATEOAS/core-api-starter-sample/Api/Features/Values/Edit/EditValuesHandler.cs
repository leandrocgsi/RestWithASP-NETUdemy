namespace Api.Features.Values.Edit
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class EditValuesHandler : IRequestHandler<EditValuesRequest, EditValuesResponse>
    {
        private readonly IUrlHelper _urlHelper;

        public EditValuesHandler(IUrlHelper urlHelper)
        {
            _urlHelper = urlHelper;
        }

        public EditValuesResponse Handle(EditValuesRequest message)
        {
            // Update object in domain

            return new EditValuesResponse(message.Id, message.Value, new[]
            {
                _urlHelper.CreateListValuesLink(),
                _urlHelper.CreateDetailValuesLink(message.Id),
                _urlHelper.CreateDeleteValuesLink(message.Id),
                _urlHelper.CreateCreateValuesLinkForValue()
            });
        }
    }
}