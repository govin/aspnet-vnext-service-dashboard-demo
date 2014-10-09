using System.Collections.Generic;

namespace AspNetVNext.ServiceDashboard
{
	public interface IServicesConfiguration
	{
		List<string> Urls {get;set;}
	}
}