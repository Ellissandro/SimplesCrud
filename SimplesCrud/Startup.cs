using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SimplesCrud.Database;
using SimplesCrud.Libraries.Login;
using SimplesCrud.Libraries.Sessao;
using SimplesCrud.Repositories;
using SimplesCrud.Repositories.Contracts;

namespace SimplesCrud
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddHttpContextAccessor();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddSession(options => {
            });

            services.AddScoped<Sessao>();
            services.AddScoped<LoginUsuario>();
            string connection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SimplesCrud;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            services.AddDbContext<SimplesCrudContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvcWithDefaultRoute();
           
        }
    }
}
