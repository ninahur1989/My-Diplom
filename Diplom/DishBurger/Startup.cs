using DishBurger.Data;
using DishBurger.Data.Cart;
using DishBurger.Data.Services;
using DishBurger.Data.Services.ServiceInterfaces;
using DishBurger.Data.Static;
using DishBurger.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DishBurger
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //for docker
            //var server = Configuration["DBServer"] ?? "localhost";
            ////var server = Configuration["DBServer"] ?? "ms-sql-server";
            //var port = Configuration["DBPort"] ?? "1433";
            //var user = Configuration["DBUSer"] ?? "SA";
            //var password = Configuration["DBPossword"] ?? "Pa55w0rd2022";
            //var database = Configuration["Database"] ?? "DishBurger2";



            //services.AddDbContext<AppDbContext>(options => 
            //options.UseSqlServer($"Server={server},{port};Initial Catalog={database};User ID ={user};Password={password}"));
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped<IIngredientsService, IngredientsService>();
            services.AddScoped<IAuthorizeService, AuthorizeService > ();
            services.AddScoped<IRestaurantsService, RestaurantsService>();
            services.AddScoped<IDishesService, DishesService>();
            services.AddScoped<IDrinksService, DrinksService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<ISortService, SortService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddMemoryCache();
            services.AddSession();
            services.AddAuthentication(options => 
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });
            services.AddAuthentication("Bearer")
             .AddJwtBearer("Bearer", options =>
             {
                 options.Authority = "http://localhost:59001";
                 // for docker
                 //options.Authority = "http://host.docker.internal:59001/connect/token";
                 options.RequireHttpsMetadata = false;
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateAudience = false
                 };
             });

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();

            app.Use(async (c, n) =>
            {
                c.Request.Headers.Add("Authorization", "Bearer " + JwtToken.currentToken);

                await n.Invoke();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


            AppDbInitializer.Seed(app);
            AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();
        }
    }
}
