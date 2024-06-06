using Microsoft.EntityFrameworkCore;
using TestSearchApplication.Data;
using TestSearchApplication.Services.DataManager;
using TestSearchApplication.Services.DataManager.Interfaces;
using TestSearchApplication.Services.SearchService;
using TestSearchApplication.Services.SearchService.Interfaces;
namespace TestSearchApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<ISearcher, SearcherAlgorithm>();
            //builder.Services.AddScoped<IDataManager, DataManager>();

            builder.Services.AddControllers();
            builder.Services.AddDbContext<DataMSAccessContext>(options => {
                options.UseJet("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=c:\\Users\\pc alhbabb\\Desktop\\SearchApplication\\M&Z_search1.accdb");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Hadiths}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
