using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;

namespace AspNetVNext.ServiceDashboard
{
    public class ServiceStatusProvider : IServiceStatusProvider
    {
        public List<ServiceStatusModel> GetServicesStatus(IEnumerable<string> serviceUrls)
        {
            return GetServicesStatusAsync(serviceUrls).Result;
        }

        private async Task<List<ServiceStatusModel>> GetServicesStatusAsync(IEnumerable<string> serviceUrls)
        {
            var urlItems = SetupURLList(serviceUrls);
            var tasks = from url in urlItems select this.GetServiceStatusAsync(url.Name, url.Url);
            var statuses = await Task.WhenAll(tasks);
            return statuses.ToList();
        }

        private List<UrlItemToProcess> SetupURLList(IEnumerable<string> serviceUrls)
        {
            var urls = new List<UrlItemToProcess>();
            foreach(var serviceUrl in serviceUrls)
            {
                var name = new Uri(serviceUrl).Host;
                urls.Add(UrlItemToProcess.Create(name, serviceUrl));
            }

            return urls;
        }

        private async Task<ServiceStatusModel> GetServiceStatusAsync(string name, string url)
        {
            var client = new HttpClient();
            var watch = new Stopwatch();
            watch.Start();
            try
            {
                var response = await client.GetAsync(url);
                watch.Stop();
                return ServiceStatusModel.Create(name, url, response.StatusCode.ToString(), watch.ElapsedMilliseconds);
            }
            catch(HttpRequestException ex)
            {
                watch.Stop();
                return ServiceStatusModel.Create(name, url, ex.Message, watch.ElapsedMilliseconds);
            }
        }
    }
}