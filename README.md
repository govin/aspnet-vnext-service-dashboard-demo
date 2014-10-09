aspnet-vnext-service-dashboard-demo
===================================

An example service status dashboard built using ASP.NET vNext.


This app makes requests in parallel against the urls specified in config.json and renders their status in a dashboard page. Please visit http://localhost:5004 after setting it up to see the dashboard.

I mainly built it to learn how to do dependency injection, configuration management, making async requests, serving requests, files and rendering views are done in ASP.NET vNext, the next version of ASP.NET. It is fully supported on linux and mac. 

There is no need for Visual Studio. It was built with just Sublime.

![Service Status Dashboard](https://github.com/govin/aspnet-vnext-service-dashboard-demo/blob/master/Service%20Information%20Dashboard.png "Service-Status")

To run,

1. Install Mono

2. Install KVM using the comand

	```
	curl https://raw.githubusercontent.com/aspnet/Home/master/kvminstall.sh | sh && source ~/.kre/kvm/kvm.sh
	```

3. Run "kvm upgrade"

3. CD in ServiceDashboard directory and perform "kpm restore"

4. Type k kestrel

5. Visit http://localhost:5004

For more installation details, refer to the ASP.NET Vnext repo - [ASPNET VNext](https://github.com/aspnet/home)

Kestrel is the new C# web server based on libuv (so there is no dependency with IIS) [Kestrel] (https://github.com/aspnet/KestrelHttpServer)

For mac folks, there is a home brew version named "kmono".




