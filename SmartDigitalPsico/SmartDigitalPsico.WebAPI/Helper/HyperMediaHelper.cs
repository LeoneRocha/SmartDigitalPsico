using Microsoft.Extensions.DependencyInjection;
using SmartDigitalPsico.Domains.Hypermedia.Filters;
using SmartDigitalPsico.Model.Hypermedia.Enricher;
using System;

namespace SmartDigitalPsico.WebAPI.Helper
{
    public static class HyperMediaHelper
    {
        public static void AddHyperMedia(IServiceCollection services)
        {
            var  filterOptions= new HyperMediaFilterOptions();

            addfilterOptions(filterOptions);

            services.AddSingleton(filterOptions);
        }

        private static void addfilterOptions(HyperMediaFilterOptions filterOptions)
        {
            filterOptions.ContentResponseEnricherList.Add(new GetGenderVOEnricher());

            filterOptions.ContentResponseEnricherList.Add(new GetUserVOEnricher());
        }
    }
}
