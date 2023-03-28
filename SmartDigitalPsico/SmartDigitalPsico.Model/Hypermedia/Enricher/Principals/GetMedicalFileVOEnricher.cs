using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Constants;
using SmartDigitalPsico.Model.VO.Medical;
using SmartDigitalPsico.Model.VO.Medical.MedicalFile;
using System.Text;

namespace SmartDigitalPsico.Model.Hypermedia.Enricher.Principals
{
    public class GetMedicalFileVOEnricher : ContentResponseEnricher<GetMedicalFileVO>

    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(GetMedicalFileVO content, IUrlHelper urlHelper)
        {
            var path = "api/Medical/v1/MedicalFile".ToLower();
            string link = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Method = HttpActionVerb.GET,
                Href = link,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Method = HttpActionVerb.POST,
                Href = link,
                Rel = RelationType.post,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Method = HttpActionVerb.PUT,
                Href = link,
                Rel = RelationType.put,
                Type = ResponseTypeFormat.DefaultPut
            });
            content.Links.Add(new HyperMediaLink()
            {
                Method = HttpActionVerb.DELETE,
                Href = link,
                Rel = RelationType.delete,
                Type = "long"
            });
            return Task.Run(() => { });//Ajuste para o resultado não lancar erro de objeto nullo
        }

        private string GetLink(long id, IUrlHelper urlHelper, string path)
        {
            lock (_lock)
            {
                var url = new { controller = path, id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            };
        }
    }
}
