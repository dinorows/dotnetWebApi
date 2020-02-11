using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// These are the libraries I added
using System.Net;
using System.Net.Http;
using System.IO;
using System.Text;

namespace donet.webapiinclass.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        // This is for synchronous calls: I make these static
        // (global) so I don;t have to recreate them every time
        // I call Get()
        static string url = "https://localhost:5001/server";
        HttpWebRequest request = WebRequest.CreateHttp(url);

        // This is for asynchronous calls: More correct, but
        // more complicated to use
        static HttpClient client_async = new HttpClient();

        // This Get() method demonstrates how to make a REST
        // call to another endpoint. A browser connects to
        // *this* enpoint (/client), which then in turn calls
        // the /server enpoint (which just return a simple string)
        [HttpGet]
        public String Get()
        {
            request.Method = "GET"; // or "POST", "PUT", "PATCH", "DELETE", etc.

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                // Get the stream associated with the response
                using (Stream responseStream = response.GetResponseStream())
                {
                    // Get a reader capable of reading the response stream
                    using (StreamReader myStreamReader = new StreamReader(responseStream, Encoding.UTF8))
                    {
                        // Read stream content as string
                        string responseJSON = myStreamReader.ReadToEnd();
                        return "The synchronous client called the server, which replied with: " +
                            responseJSON;
                        
                        // Assuming the response is in JSON format, deserialize it
                        // creating an instance of TData type (generic type declared before).
                        // You need to Install-Package Newtonsoft.Json
                        //data = JsonConvert.DeserializeObject<TData>(responseJSON);
                    }
                }   
            }
        }
    }
}
