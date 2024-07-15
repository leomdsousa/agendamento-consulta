﻿using System.Collections.Generic;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AgendamentoConsulta.Data;
using AgendamentoConsulta.Services;
using AgendamentoConsulta.Services.Interfaces;
using AgendamentoConsulta.Repositorio.Interfaces;
using AgendamentoConsulta.Repositorio;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AgendamentoConsulta
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
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<AlbertEinsteinTesteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AlbertEinsteinTesteContext")));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(config => 
                    {
                        config.LoginPath = "/Home/Index";
                        config.AccessDeniedPath = "/Home/Error";
                    });

            //Serviços
            services.AddScoped<SeedingService>();
            services.AddScoped<IConsultaService, ConsultaService>();
            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IPacienteService, PacienteService>();

            //Repositorios
            services.AddScoped<IConsultaRepository, ConsultaRepository>();
            services.AddScoped<IMedicoRepository, MedicoRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, SeedingService seedingService)
        {
            var enUs = new CultureInfo("en-US");
            var localizationOption = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(enUs),
                SupportedCultures = new List<CultureInfo> { enUs },
                SupportedUICultures = new List<CultureInfo> { enUs }
            };

            app.UseRequestLocalization(localizationOption);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            //app.UseAntiforgery();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}");
            });
        }
    }
}
