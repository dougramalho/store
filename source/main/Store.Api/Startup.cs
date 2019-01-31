using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Store.Core.Mappers;
using Store.Core.Repositories;
using Store.Core.Repositories.Blog;
using Store.Core.Repositories.Category;
using Store.Core.Repositories.Product;
using Store.Core.Services;
using Store.Core.Services.Blog;
using Store.Core.Services.Category;
using Store.Core.Services.Product;

namespace Store.Api {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_2);

            services.AddSingleton<IProductRepository, ProductRepository> ();
            services.AddSingleton<IBlogRepository, BlogRepository> ();
            services.AddSingleton<IBlogService, BlogService> ();
            
            services.AddSingleton<ICategoryRepository, CategoryRepository> ();
            services.AddSingleton<ICategoryService, CategoryService> ();

            services.AddScoped<IProductService, ProductService> ();
            services.AddScoped<IProductDetailService, ProductDetailService> ();
            services.AddSingleton<IMapper> (_ => AutoMapperConfig.GetMapper ());
            services.Configure<MockBase> (Configuration.GetSection ("MockBase"));
            services.AddSingleton<IStoreMockBuilder, StoreMockBuilder> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            var serviceProvider = app.ApplicationServices;
            
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                var mockBase = serviceProvider.GetService<IOptions<MockBase>> ();

                if(mockBase.Value.UseMock){
                    var builder = serviceProvider.GetService<IStoreMockBuilder> ();
                    builder.Mock();
                }

            } else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}