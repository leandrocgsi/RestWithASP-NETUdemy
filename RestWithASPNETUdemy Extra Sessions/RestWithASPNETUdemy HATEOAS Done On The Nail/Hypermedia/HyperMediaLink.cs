namespace Hypermedia
{
    /// <summary>
    /// Represents a HyperMedia Link
    /// </summary>
    public class HyperMediaLink
    {
        /// <summary>
        /// The relationship between the object being returned and the object described by the link. In this case "self" indicates that the link is a reference back to the object itself.
        /// Helper types can be obtained from the RelationType
        /// </summary>
        public string Rel { get; set; }

        // Workarond for issues with slash encode https://github.com/aspnet/Home/issues/2669, https://github.com/aspnet/Routing/issues/363, https://github.com/aspnet/Home/issues/2669, https://github.com/aspnet/Routing/issues/363 and https://github.com/aspnet/Mvc/issues/2826
        // Here is the ASP.NET Core 5 controller sample code: https://github.com/doggy8088/CatchAllRouteProblem/blob/master/MVC5/Controllers/HomeController.cs
        // Here is the ASP.NET Core 2.0 controller sample code: https://github.com/doggy8088/CatchAllRouteProblem/blob/master/Core2MVC/Controllers/HomeController.cs
        private string href;

        /// <summary>
        /// The hyperlink (Href) for the object being described by the link in the form of a URI
        /// </summary>
        public string Href
        {
            get {
                return href.Replace("%2F", "/");
            }
            set {
                href = value;
            }
        }

        /// <summary>
        /// The format of any data (Types) that should be provided in the HTTP request or that can be returned in the response, depending on the type of the request.
        /// Types can be provided by the  ResponseTypeFormat helper class
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// The type of HTTP request (Action) that can be sent to this URI.
        /// Action names can be provider by the HttpActionVerb Helper class
        /// </summary>
        public string Action { get; set; }
    }
}