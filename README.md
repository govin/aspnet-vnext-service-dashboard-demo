aspnet-vnext-service-dashboard-demo
===================================

An example services dashboard built using ASP.NET VNext.


This app makes requests in parallel against the urls specified in config.json and renders their status in a dashboard page. 

I mainly built it to learn how to do dependency injection, configuration management, making async requests, serving requests, files and rendering views are done in ASP.NET VNext, the next version of ASP.NET. It is fully supported on linux and mac. 

It was built without Visual Studio and with just sublime text editor.

To run,

1. Install Mono
2. Install KVM and upgrade it
3. CD in ServiceDashboard directory and perform "kpm restore"
4. Type K kestrel

For more installation details, refer to the ASP.NET Vnext repo - [ASPNET VNext](https://github.com/aspnet/home)

Kestrel is the new C# web server based on libuv (so there is no dependency with IIS) [Kestrel] (https://github.com/aspnet/KestrelHttpServer)

For mac, folks, there is a home brew version named "kmono".

