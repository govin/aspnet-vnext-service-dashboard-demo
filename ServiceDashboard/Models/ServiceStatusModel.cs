using System;

namespace AspNetVNext.ServiceDashboard
{
	public class ServiceStatusModel
	{
		public string ServiceName {get;set;}

		public string Status {get;set;}

		public string HostIp {get;set;}

		public string StatusUrl {get;set;}

		public double ResponseTimeMS {get;set;}

		public static ServiceStatusModel Create(string name, string url, string status, double responseTimeMS)
		{
			var hostIp = NetworkExtensions.GetIpAddress(new Uri(url).Host);
			return new ServiceStatusModel()
			{
                ServiceName = name,
                Status = status,
                StatusUrl = url,
                HostIp = hostIp,
                ResponseTimeMS = responseTimeMS
			};
		}

		public override string ToString()
		{
			return string.Format("Name: {0}, Url: {1}, Status: {2}, ResponseTimeMS: {3}", 
				this.ServiceName,
				this.StatusUrl,
				this.Status,
				this.ResponseTimeMS);
		}
	}
}