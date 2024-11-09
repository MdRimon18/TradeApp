using DocTimes.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pms.Data.Repository.Accounts;
using Pms.Data.Repository.Shared;
using Pms.Data.Repository;
using TradeApp.Services.Accounts;
using TradeApp.Services.Inventory;
using TradeApp.Services;
using TradeApp.DbContex;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//IConfiguration configuration;

//configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

//builder.Services.AddDbContext<practiceDbContext>

//   (option => option
//   .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
//   .EnableSensitiveDataLogging());

builder.Services.AddSingleton<DbConnection>();
builder.Services.AddScoped<ProductRepository>();
//builder.Services.AddScoped<TaskService>();
//builder.Services.AddScoped<OrderService>();
//builder.Services.AddScoped<OrderServiceWithSp>();
builder.Services.AddScoped<ColorService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<InvoiceItemService>();
builder.Services.AddScoped<ProductSpecificationService>();
builder.Services.AddScoped<ProductSkuService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<NotificationByService>();
builder.Services.AddScoped<CountryServiceV2>();
builder.Services.AddScoped<ShippingByService>();
builder.Services.AddScoped<UnitService>();
builder.Services.AddScoped<BusinessTypesService>();
builder.Services.AddScoped<RoleService>();
builder.Services.AddScoped<InvoiceTypeService>();
builder.Services.AddScoped<LocationService>();
builder.Services.AddScoped<ProductOrCupponCodeService>();
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<EmailSetupService>();
builder.Services.AddScoped<SmsSettinsService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<BasicColumnPermissionService>();
builder.Services.AddScoped<PageDetailsService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<SupplierService>();
builder.Services.AddScoped<LanguageService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<AccHeadService>();
builder.Services.AddScoped<StatusSettingService>();
builder.Services.AddScoped<CurrencyService>();
builder.Services.AddScoped<ProductSubCategoryService>();
builder.Services.AddScoped<BrandService>();
builder.Services.AddScoped<ProductSizeService>();
builder.Services.AddScoped<CompanyBranceService>();
builder.Services.AddScoped<CustomerPaymentDtlsService>();
builder.Services.AddScoped<ProductSerialNumbersService>();
builder.Services.AddScoped<AccountsDailyExpanseService>();
builder.Services.AddScoped<PaymentTypesService>();
builder.Services.AddScoped<BillingPlanService>();
builder.Services.AddScoped<AccTypeServivce>();
builder.Services.AddScoped<BrandService>();
//builder.Services.AddScoped<BodyPartService>();
builder.Services.AddScoped<ProductMediaService>();
//builder.Services.AddSingleton<ProductRepositoyWithSp>();
builder.Services.AddSingleton<TaskRepository>();
builder.Services.AddSingleton<FileUploadService>();
// Program.cs
builder.Services.AddSingleton<ToastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
