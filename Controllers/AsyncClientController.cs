using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// These are the libraries I added
using System.Net.Http;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Authentication.Cookies;

namespace donet.webapiinclass.Controllers
{
    //[Authorize(AuthenticationSchemes = AuthSchemes)]
    [ApiController]
    [Route("[controller]")]
    public class AsyncClientController : ControllerBase
    {
        static string oopsie()
        {
            return "oopsie!";
        }

        //private const string AuthSchemes =
        //    CookieAuthenticationDefaults.AuthenticationScheme; 

        // This is for asynchronous calls: More correct, but
        // more complicated to use!
        static HttpClient client_async = new HttpClient();

        // This Get() method demonstrates how to make an asynchronous REST
        // call to another endpoint. A browser connects to
        // *this* enpoint (/asyncclient), which then in turn calls
        // the /server enpoint (which just return a simple string)
        // This is an asynchronous GET:
        static async Task<String> GetAsync()
        {
            HttpResponseMessage response = await 
                client_async.GetAsync("https://localhost:5001/server");
            if (response.IsSuccessStatusCode)
            {
                return "The asynchronous client called the server, which replied with :" + 
                    await response.Content.ReadAsStringAsync();
            }
            return await Task.Run(oopsie);
        }

        [HttpGet]
        public String Get()
        {
            return GetAsync().Result;
        }
    }
}
