using HyperMedia;
using Microsoft.AspNetCore.Mvc;
using RestWithASPNETUdemy.Data.VO;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.HyperMedia
{
    public class PersonEnricher : ObjectContentResponseEnricher<PersonVO>
    {
        //SEE: https://books.google.com.br/books?id=D54TAwAAQBAJ&pg=PA146&lpg=PA146&dq=Href+%3D+urlHelper.Link(%22DefaultApi%22&source=bl&ots=WuQj7v4KD9&sig=Ock40NqChWq0DZrs7thDImBsv4E&hl=pt-BR&sa=X&ved=0ahUKEwjT-7_u1orbAhVJgJAKHQJ7AZMQ6AEIVDAE#v=onepage&q=Href%20%3D%20urlHelper.Link(%22DefaultApi%22&f=false

        protected override Task EnrichModel(PersonVO content, IUrlHelper urlHelper)
        {
            var path = "persons/v1";
            //var path = "persons/v{version:apiVersion}";

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