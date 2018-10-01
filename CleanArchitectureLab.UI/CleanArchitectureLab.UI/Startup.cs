using CleanArchitectureLab.Core.Application.Tarefas.Concluir;
using CleanArchitectureLab.Core.Application.Tarefas.Criar;
using CleanArchitectureLab.Core.Application.Tarefas.Listar;
using CleanArchitectureLab.Core.Application.Usuarios.Criar;
using CleanArchitectureLab.Core.Application.Usuarios.Listar;
using CleanArchitectureLab.Core.Domain.Tarefas;
using CleanArchitectureLab.Core.Persistance;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace CleanArchitectureLab.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionString = Startup.Configuration["connectionStrings:tarefasDBConnectionString"];
            services.AddDbContext<TarefasContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ICriarUsuarioCommand, CriarUsuarioCommand>();
            services.AddScoped<IListarUsuariosQuery, ListarUsuariosQuery>();
            services.AddScoped<IConcluirTarefaCommand, ConcluirTarefaCommand>();
            services.AddScoped<ICriarTarefaCommand, CriarTarefaCommand>();
            services.AddScoped<IListarTarefaCommand, ListarTarefaCommand>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }



            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();

            app.UseMvc();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<UsuarioDto, Usuario>();
                cfg.CreateMap<IEnumerable<ListaTarefasDto>, List<Tarefa>>();
                cfg.CreateMap<CriarTarefaDto, Tarefa>();
            });
        }
    }
}
