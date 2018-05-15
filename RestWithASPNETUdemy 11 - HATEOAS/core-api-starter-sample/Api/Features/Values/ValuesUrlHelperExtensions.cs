namespace Api.Features.Values
{
    using Delete;
    using Detail;
    using Edit;
    using List;
    using Microsoft.AspNetCore.Mvc;

    public static class ValuesUrlHelperExtensions
    {
        public static Link CreateListValuesLink(this IUrlHelper urlHelper)
        {
            return new Link
            {
                Type = "GET",
                Rel = "values",
                Href = urlHelper.Link(ValuesController.GetListRouteName, new ListValuesRequest())
            };
        }

        public static Link CreateDetailValuesLink(this IUrlHelper urlHelper, int id)
        {
            return new Link
            {
                Type = "GET",
                Rel = "self",
                Href = urlHelper.Link(ValuesController.GetByIdRouteName, new DetailValuesRequest {Id = id})
            };
        }

        public static Link CreateEditValuesLink(this IUrlHelper urlHelper, int id)
        {
            return new Link
            {
                Type = "PUT",
                Rel = "self",
                Href = urlHelper.Link(ValuesController.PutRouteName, new EditValuesRequest {Id = id})
            };
        }

        public static Link CreateDeleteValuesLink(this IUrlHelper urlHelper, int id)
        {
            return new Link
            {
                Type = "DELETE",
                Rel = "self",
                Href = urlHelper.Link(ValuesController.DeleteRouteName, new DeleteValuesRequest {Id = id})
            };
        }

        public static Link CreateCreateValuesLinkForCollection(this IUrlHelper urlHelper)
        {
            return new Link
            {
                Type = "POST",
                Rel = "self",
                Href = urlHelper.Link(ValuesController.PostRouteName, null)
            };
        }

        public static Link CreateCreateValuesLinkForValue(this IUrlHelper urlHelper)
        {
            return new Link
            {
                Type = "POST",
                Rel = "values",
                Href = urlHelper.Link(ValuesController.PostRouteName, null)
            };
        }

        // Create link to foo
        //public static Link CreateFooValuesLink(this IUrlHelper urlHelper)
        //{
        //    return new Link
        //    {
        //        Type = "GET",
        //        Rel = "foo",
        //        Href = urlHelper.Link(FooController.GetByIdFooRouteName, null)
        //    };
        //}
    }
}