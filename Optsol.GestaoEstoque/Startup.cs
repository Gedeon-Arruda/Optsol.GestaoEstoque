using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Optsol.GestaoEstoque.Application.Mappers;
using Optsol.GestaoEstoque.Application.Services;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using Optsol.GestaoEstoque.Infra.Data;
using Optsol.GestaoEstoque.Infra.Repositorios;
using System;
using System.IO;

namespace Optsol.GestaoEstoque
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Optsol.GestaoEstoque",
                    Version = "v1",
                    Contact = new OpenApiContact
                    {
                        Name = "Gedeon Arruda",
                        Email = "gedeon.arruda@optsol.com.br",
                        Url = new Uri("https://www.linkedin.com/in/gedeon-arruda-a37a01170/")
                    }
                });

                var xmlFile = "Optsol.GestaoEstoque.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                c.IncludeXmlComments(xmlPath);
            });

            services.AddDbContext<GestaoEstoqueContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(ProdutoMapper).Assembly);

            services.AddScoped<IProdutoServiceApplication, ProdutoServiceApplication>();
            services.AddScoped<IDepositoServiceApplication, DepositoServiceApplication>();
            services.AddScoped<IVendaServiceApplication, VendaServiceApplication>();

            services.AddScoped<IVendaRepository, VendaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<IDepositoRepository, DepositoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Optsol.GestaoEstoque v1"));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}