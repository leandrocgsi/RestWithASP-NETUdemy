using HyperMedia;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Data.VO;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.HyperMedia
{
    public class PersonEnricher : ObjectContentResponseEnricher<PersonVO>
    {
        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "persons";

            //https://blogs.msdn.microsoft.com/roncain/2012/07/17/using-the-asp-net-web-api-urlhelper/
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = urlHelper.Link("DefaultApi", new { controller = path, id = content.Id }),
                Rel = RelationType.self,
                Type = RensponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = urlHelper.Link("DefaultApi", new { controller = path, id = content.Id }),
                Rel = RelationType.self,
                Type = RensponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = urlHelper.Link("DefaultApi", new { controller = path, id = content.Id }),
                Rel = RelationType.self,
                Type = RensponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = urlHelper.Link("DefaultApi", new { controller = path, id = content.Id }),
                Rel = RelationType.self,
                Type = "int"
            });
            return null;
        }
    }
}