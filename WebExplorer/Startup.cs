/*
* Copyright � SpreadsheetGear LLC. All Rights Reserved.
* 
* SpreadsheetGear� is a registered trademark of SpreadsheetGear LLC.
*/

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebExplorer
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
            // NOTE: 
            // SpreadsheetGear products distributed on NuGet are by default in a "Free" mode which places 
            // certain limits on its usage in this mode:
            //   - 1,000 rows x 100 columns x 10 worksheets x 3 workbooks
            //
            // These samples are setup in a way that stays within these limits, and so a Signed License 
            // string (which expands on these limits) is not required.  However, if they are modified, the 
            // above limits could be hit and an exception could be thrown.  If this occurs, you can activate 
            // the unlimited mode by providing a "Signed License" string.  If you are a Licensed user of 
            // SpreadsheetGear, you can visit the SpreadsheetGear Licensed User Downloads page to generate 
            // a Signed License string from your License Number:
            //  - https://www.spreadsheetgear.com/Downloads/Licensed
            //
            // If you would like to evaluate the unlimited mode of SpreadsheetGear for 30 days, you can 
            // generate a Signed Trial License from the SpreadsheetGear Evaluation Downloads page:
            //  - https://www.spreadsheetgear.com/Downloads/Evaluation
            //
            // Once you have your Signed License, replace it with the below line of code:
            // SpreadsheetGear.Factory.SetSignedLicense("MY SIGNED LICENSE HERE");

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();
            services.AddSingleton<SamplesService>();
            services.AddAutoMapper(typeof(AutoMapperProfiler));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
