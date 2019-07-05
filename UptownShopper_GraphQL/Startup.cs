using GraphiQl;
using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Http;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UptownShopper_GraphQL.Data;
using UptownShopper_GraphQL.Entities;
using UptownShopper_GraphQL.GraphQL;

namespace UptownShopper_GraphQL
{
  public class Startup
  {
    private IConfigurationRoot Configuration { get; set; }

    public Startup(IHostingEnvironment env)
    {
     var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

//      if (env.IsDevelopment())
//      {
//        builder.AddUserSecrets<Startup>();
//        run this to use that ^: dotnet user-secrets set DefaultConnection 'your-connection-string'
//      }

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
      services.AddSingleton<IDocumentWriter, DocumentWriter>();
      services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
      services.AddSingleton<IDataLoaderContextAccessor, DataLoaderContextAccessor>();  
      services.AddSingleton<DataLoaderDocumentListener>(); 
      
      services.AddScoped<ItemQuery>();  
      services.AddScoped<ItemMutation>();
      services.AddScoped<ISchema, ItemSchema>();
      
      services.AddScoped<ItemType>();
      services.AddScoped<ItemInputType>();  
      
      services.AddScoped<StoreType>();
      services.AddScoped<StoreInputType>();
      
      services.AddScoped<StoreItemType>();  
      services.AddScoped<StoreItemInputType>();
      
      services.AddScoped<IDataStore, DataStore>();
      
//      services.AddGraphQL(new GraphQLOptions() { ExposeExceptions=true});
      
      services.AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(
        options => options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
      );
      
      services.AddCors(options =>
      {
        options.AddPolicy("CorsPolicy",
          builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials() );
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseDefaultFiles();
      app.UseStaticFiles();
      
      app.UseCors("CorsPolicy");
      
      app.UseMiddleware<GraphQLMiddleware>();
      app.UseGraphiQl("/api/graphql");
      new ApplicationDatabaseInitializer().SeedAsync(app).GetAwaiter();
    }
  }
}