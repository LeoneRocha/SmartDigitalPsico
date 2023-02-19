using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;
using SmartDigitalPsico.Domains.Hypermedia.Abstract;
using SmartDigitalPsico.Domains.Hypermedia.Utils;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace SmartDigitalPsico.Domains.Hypermedia
{
    public abstract class ContentResponseEnricher<T> : IResponseEnricher where T : ISupportsHyperMedia
    {
        public ContentResponseEnricher()
        {

        }
        public virtual bool CanEnrich(Type contentType)
        {
            bool isCanEnrich = contentType == typeof(T) || contentType == typeof(List<T>) || contentType == typeof(PagedSearchVO<T>)
                || contentType == typeof(ServiceResponse<T>);

            isCanEnrich = true;

            return isCanEnrich;
        }

        protected abstract Task EnrichModel(T content, IUrlHelper urlHelper);

        bool IResponseEnricher.CanEnrich(ResultExecutingContext response)
        {
            if (response.Result is OkObjectResult okObjectResult)
            {
                return CanEnrich(okObjectResult.Value.GetType());
            }
            return false;
        }
        public async Task Enrich(ResultExecutingContext response)
        {
            var urlHelper = new UrlHelperFactory().GetUrlHelper(response);
            //SIngle 
            if (response.Result is OkObjectResult okObjectResult)
            {
                if (okObjectResult.Value is ServiceResponse<T> serviceResponse)
                {
                    if (serviceResponse.Data is T model)
                    {
                        await EnrichModel(model, urlHelper);
                    }
                    else if (serviceResponse.Data is List<T> collection)
                    {
                        ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                        Parallel.ForEach(bag, (element) =>
                        {
                            EnrichModel(element, urlHelper);
                        });
                    }
                }
                //LIST
                else if (okObjectResult.Value is ServiceResponse<List<T>> serviceResponse2) 
                {
                    if (serviceResponse2.Data is List<T> collection)
                    {
                        ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                        Parallel.ForEach(bag, (element) =>
                        {
                            EnrichModel(element, urlHelper);
                        });
                    }

                }
                else if (okObjectResult.Value is T model)
                {
                    await EnrichModel(model, urlHelper);
                }
                else if (okObjectResult.Value is List<T> collection)
                {
                    ConcurrentBag<T> bag = new ConcurrentBag<T>(collection);
                    Parallel.ForEach(bag, (element) =>
                    {
                        EnrichModel(element, urlHelper);
                    });
                }
                else if (okObjectResult.Value is PagedSearchVO<T> pagedSearch)
                {
                    Parallel.ForEach(pagedSearch.List.ToList(), (element) =>
                    {
                        EnrichModel(element, urlHelper);
                    });
                }
            }
            await Task.FromResult<object>(null);
        }
    }
}
