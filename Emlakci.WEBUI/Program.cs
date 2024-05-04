using Emlakci.BLL.Abstract;
using Emlakci.BLL.Concrete;
using Emlakci.DAL.Abstract;
using Emlakci.DAL.Concrete.EfCore;
using Emlakci.WEBUI.Mapping;

namespace Emlakci.WEBUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(typeof(MappingProfile));
            // ************ DEPENDENCY INJECTION *************
           
            builder.Services.AddScoped<ICategoryService, CategoryManager>();
            builder.Services.AddScoped<ICategoryDal, EfCoreCategoryDal>();

            builder.Services.AddScoped<IProductService, ProductManager>();
            builder.Services.AddScoped<IProductDal, EfCoreProductDal>();

            builder.Services.AddScoped<IEmploymentService, EmploymentManager>();
            builder.Services.AddScoped<IEmploymentDal, EfCoreEmploymentDal>();

            builder.Services.AddScoped<IWhoWeAreService, WhoWeAreManager>();
            builder.Services.AddScoped<IWhoWeAreDal, EfCoreWhoWeAreDal>();

            builder.Services.AddScoped<IAgencyService, AgencyManager>();
            builder.Services.AddScoped<IAgencyDal, EfCoreAgencyDal>();

            builder.Services.AddScoped<IClientService, ClientManager>();
            builder.Services.AddScoped<IClientDal, EfCoreClientDal>();

            builder.Services.AddScoped<IContactService, ContactManager>();
            builder.Services.AddScoped<IContactDal, EfCoreContactDal>();

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
                pattern: "{controller=Admin}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
