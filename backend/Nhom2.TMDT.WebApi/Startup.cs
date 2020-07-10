using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nhom2.TMDT.Data.Services;
using Nhom2.TMDT.Service.Account.Login.Queries;
using Nhom2.TMDT.Service.Account.Queries.ForgetPassword;
using Nhom2.TMDT.Service.Account.Queries.Register;
using Nhom2.TMDT.Service.Admin.Queries.ConfirmOrder;
using Nhom2.TMDT.Service.Admin.Queries.GetOrderManager;
using Nhom2.TMDT.Service.Home.Queries.GetSlideProduct;
using Nhom2.TMDT.Service.Home.Queries.GetSlideProductNew;
using Nhom2.TMDT.Service.Mail.SendMail;
using Nhom2.TMDT.Service.Order.Commands.UpdateShipmentDetail;
using Nhom2.TMDT.Service.Order.Queries.CreateOrderCart;
using Nhom2.TMDT.Service.Order.Queries.GetDeliveryMethod;
using Nhom2.TMDT.Service.Order.Queries.GetOrder;
using Nhom2.TMDT.Service.Order.Queries.GetOrderDetail;
using Nhom2.TMDT.Service.Order.Queries.GetPaymentMethod;
using Nhom2.TMDT.Service.Order.Queries.GetShipmentDetail;
using Nhom2.TMDT.Service.Product.Commands.CreateComment;
using Nhom2.TMDT.Service.Product.Commands.CreateRate;
using Nhom2.TMDT.Service.Product.Commands.DeleteCommand;
using Nhom2.TMDT.Service.Product.Commands.UpdateComment;
using Nhom2.TMDT.Service.Product.Queries.GetCategory;
using Nhom2.TMDT.Service.Product.Queries.GetComment;
using Nhom2.TMDT.Service.Product.Queries.GetProduct;
using Nhom2.TMDT.Service.Product.Queries.GetProductDetail;
using Nhom2.TMDT.Service.Product.Queries.GetRate;
using Nhom2.TMDT.Service.Product.Queries.GetRelatedProduct;
using System;

namespace Nhom2.TMDT.WebApi
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), builder =>
                {
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });

            services.AddOptions();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(Configuration.GetSection("AllowOrigins:Allow").Value).AllowCredentials()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            services.AddControllers();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            //api
            services.AddScoped<ILoginQuery, LoginQuery>();
            services.AddScoped<IGetSlideProductHotQuery, GetSlideProductHotQuery>();
            services.AddScoped<IGetSlideProductNewQuery, GetSlideProductNewQuery>();
            services.AddScoped<IGetProductQuery, GetProductQuery>();
            services.AddScoped<IGetRelatedProductQuery, GetRelatedProductQuery>();
            services.AddScoped<IGetProductDetailQuery, GetProductDetailQuery>();
            services.AddScoped<IGetCommentQuery, GetCommentQuery>();
            services.AddScoped<IGetRateQuery, GetRateQuery>();
            services.AddScoped<IGetOrderQuery, GetOrderQuery>();
            services.AddScoped<IGetOrderManagerQuery, GetOrderManagerQuery>();
            services.AddScoped<IGetOrderDetailQuery, GetOrderDetailQuery>();
            services.AddScoped<IConfirmOrderQuery, ConfirmOrderQuery>();
            services.AddScoped<IGetDeliveryMethodQuery, GetDeliveryMethodQuery>();
            services.AddScoped<ICreateOrderCartQuery, CreateOrderCartQuery>();
            services.AddScoped<IGetPaymentMethodQuery, GetPaymentMethodQuery>();
            services.AddScoped<IGetCategoryQuery, GetCategoryQuery>();
            services.AddScoped<ICreateCommentCommand, CreateCommentCommand>();
            services.AddScoped<ICreateRateCommand, CreateRateCommand>();
            services.AddScoped<IUpdateShipmentDetailCommand, UpdateShipmentDetailCommand>();
            services.AddScoped<IGetShipmentDetailQuery, GetShipmentDetailQuery>();
            services.AddScoped<ISendMail, SendMail>();
            services.AddScoped<IForgetPasswordQuery, ForgetPasswordQuery>();
            services.AddScoped<IUpdateCommentCommand, UpdateCommentCommand>();
            services.AddScoped<IDeleteCommentCommand, DeleteCommentCommand>();
            services.AddScoped<IRegisterQuery, RegisterQuery>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
