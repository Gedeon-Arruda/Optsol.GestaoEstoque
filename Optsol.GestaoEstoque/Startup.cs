using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Optsol.GestaoEstoque.Application.Mappers;
using Optsol.GestaoEstoque.Application.Services;
using Optsol.GestaoEstoque.Application.Services.Interfaces;
using Optsol.GestaoEstoque.Dominio.Repositorios;
using Optsol.GestaoEstoque.Infra.Data;
using Optsol.GestaoEstoque.Infra.Repositorios;

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
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Optsol.GestaoEstoque", Version = "v1" });
            });

            services.AddDbContext<GestaoEstoqueContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddAutoMapper(typeof(ProdutoMapper).Assembly);
            //services.AddAutoMapper(typeof(DepositoMapper));
            //services.AddAutoMapper(typeof(VendaMapper));

            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Optsol.GestaoEstoque v1"));
            }

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