using AutoMapper;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQLEntityFramework.Data.AutoMapperProfile;
using GraphQLEntityFramework.Data.Entities;
using GraphQLEntityFramework.Data.Repositories;
using GraphQLEntityFrameWork.GraphQL.GQueries;
using GraphQLEntityFrameWork.GraphQL.GSchema;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GraphQLEntityFramework
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
           
            services.AddDbContext<BlogDBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbConnectionString"))); 
            services.AddScoped<BlogRepository>();
            services.AddScoped<ReviewsRepository>();

            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddScoped<MapperConfiguration>(s=>mapperConfiguration);
            var mapper = mapperConfiguration.CreateMapper();
            services.AddSingleton<IMapper>(mapper);


            //***< GraphQL Services >*** 

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddScoped<IDependencyResolver>(x =>
                new FuncDependencyResolver(x.GetRequiredService));

            services.AddScoped<BlogSchema>();

            services.AddGraphQL(x =>
            {
                x.ExposeExceptions = true;  
            })
               .AddGraphTypes(typeof(BlogQuery).Assembly, ServiceLifetime.Scoped)
                .AddUserContextBuilder(httpContext => httpContext.User)
                .AddDataLoader();

            //***</ GraphQL Services >*** 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseGraphQL<BlogSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseRouting();

             

         
        }

        
    }
}
