using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using System.Net;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace donet.webapiinclass
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // IF you enable authorization with app.UseAuthorization(); then you need to:
            // To fix the runtime error System.Net.WebException: The SSL connection 
            // could not be established, see inner exception. The remote certificate 
            // is invalid according to the validation procedure.
            // Goes without saying, do not use this in production code!
            //ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;

            // This is one possible authentication mechanism (cookies)
            //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            //    .AddCookie();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //~dk commented this out so i won't get redirected to an HTTPS
            // address when i enter an HTTP url
            //app.UseHttpsRedirection();

            app.UseRouting();

            //~ dk commented out!
            //app.UseAuthorization();

            //~dk if you use authorization, you need to be able to authenticate..
            //app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
