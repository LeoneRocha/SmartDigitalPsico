using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Constants;
using SmartDigitalPsico.Model.Contracts;
using SmartDigitalPsico.Model.VO;
using System.Text;

namespace RestWithASPNETUdemy.Hypermedia.Enricher
{
    public class ServiceResponseEnricher<TResult> : ContentResponseEnricher<ServiceResponse<TResult>>
    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(ServiceResponse<TResult> content, IUrlHelper urlHelper)
        {
            var path = "api/Gender/v1";
            int idObject = 0;
            try
            {
                var obId = content.Data.GetType().GetProperty("Id");
                //percorrer se for uma lista e oegar o id de cada item 
                if (obId != null)
                { 
                    int.TryParse(obId.GetValue(content.Data, null).ToString(), out idObject);
                }
            }
            catch (Exception)
            {

                throw;
            }
            //content.Data.Id
            string link = GetLink(idObject, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPut
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.self,
                Type = "int"
            });
            return Task.Run(() => { });//Ajuste para o resultado não lancar erro de objeto nullo
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id = id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}
