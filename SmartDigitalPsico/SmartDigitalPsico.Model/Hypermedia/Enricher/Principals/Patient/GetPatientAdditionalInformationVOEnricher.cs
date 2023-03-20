using Microsoft.AspNetCore.Mvc;
using SmartDigitalPsico.Domains.Hypermedia;
using SmartDigitalPsico.Domains.Hypermedia.Constants;
using SmartDigitalPsico.Model.VO.Patient.PatientAdditionalInformation;
using System.Text;

namespace SmartDigitalPsico.Model.Hypermedia.Enricher.Principals.Patient
{
    public class GetPatientAdditionalInformationVOEnricher : ContentResponseEnricher<GetPatientAdditionalInformationVO>

    {
        private readonly object _lock = new object();
        protected override Task EnrichModel(GetPatientAdditionalInformationVO content, IUrlHelper urlHelper)
        {
            var path = "api/Patient/v1/PatientAdditionalInformation/".ToLower();
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
