# dotnetWebApi

This is a demo project that demonstrates how to set up a simple WebAPI endpoint (URL http://localhost:5000/server), 
and how to call that endpoint synchronously wih the HttpWebRequest dotnet object (URL http://localhost:5000/client),
as well as asynchronously with the HttpClient dotnet object (URL http://localhost:5000/asyncclient).

In other words, this demo project is both a WebAPI server endpoint, and offers endpoints that call on the server endpoint
to demonstrate how to create (synchronous and asynchronous) REST calls with dotnet.

Note that I turned off Authentication by commenting out app.UseAuthentication() is Startup.cs, otherwise
you need to enable Authorization and find a mechanism to authorize.

Download to a folder, make sure you're using the latest dotnet runtime, dotnet build. dotnet run, and you're in business.
