using System.Collections.Generic;

namespace AspNetVNext.ServiceDashboard
{
	public interface IServiceStatusProvider
	{
		List<ServiceStatusModel> GetServicesStatus(IEnumerable<string> services);
	}
}