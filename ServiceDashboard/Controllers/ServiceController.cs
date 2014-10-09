using Microsoft.AspNet.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AspNetVNext.ServiceDashboard
{
	[Route("api")]
	public class ServiceController : Controller
	{
	   private readonly IServiceStatusProvider provider;

	   private readonly IServicesConfiguration config;

		public ServiceController(IServiceStatusProvider provider, IServicesConfiguration config)
		{
			this.provider = provider;
			this.config = config;
		}

		[HttpGet("serviceinfo")]
		public List<ServiceStatusModel> Get()
		{
			return this.provider.GetServicesStatus(config.Urls);
		}
	}
}