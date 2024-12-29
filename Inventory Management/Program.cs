<<<<<<< HEAD
using System.Net.Mime;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

=======
using Microsoft.EntityFrameworkCore;
using Plugins.DataStore.InMemory;
using Plugins.DataStore.SQL;
using System.Net.Mime;
using System.Text;
using UseCases;
using UseCases.CategoriesUseCases;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases;
using Inventory_Management.Data;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AccountContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagement"));
});

builder.Services.AddDbContext<InventoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("InventoryManagement"));
});

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AccountContext>();

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
	options.AddPolicy("Inventory", p => p.RequireClaim("Role", "Inventory", "Admin"));
	options.AddPolicy("Sellers", p => p.RequireClaim("Role", "Seller","Admin"));
});

if(builder.Environment.IsEnvironment("StaticDB"))
{
	builder.Services.AddSingleton<ICategoryRepository, CategoriesInMemoryRepository>();
	builder.Services.AddSingleton<IProductRepository, ProductsInMemoryRepository>();
	builder.Services.AddSingleton<ITransactionRepository, TransactionsInMemoryRepository>();
}
else
{
	builder.Services.AddTransient<ICategoryRepository, CategorySQLRepository>();
	builder.Services.AddTransient<IProductRepository, ProductSQLRepository>();
	builder.Services.AddTransient<ITransactionRepository, TransactionSQLRepository>();
}

builder.Services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
builder.Services.AddTransient<IViewSelectedCategoryUseCase, ViewSelectedCategoryUseCase>();
builder.Services.AddTransient<IEditCategoryUseCase, EditCategoryUseCase>();
builder.Services.AddTransient<IAddCategoryUseCase, AddCategoryUseCase>();
builder.Services.AddTransient<IDeleteCategoryUseCase,DeleteCategoryUseCase>();

builder.Services.AddTransient<IViewProductsUseCase, ViewProductsUseCase>();
builder.Services.AddTransient<IAddProductUseCase, AddProductUseCase>();
builder.Services.AddTransient<IEditProductUseCase, EditProductUseCase>();
builder.Services.AddTransient<IViewProductsInCategoryUseCase, ViewProductsInCategoryUseCase>();
builder.Services.AddTransient<IDeleteProductUseCase, DeleteProductUseCase>();
builder.Services.AddTransient<IViewSelectedProductUseCase, ViewSelectedProductUseCase>();
builder.Services.AddTransient<ISellProductUseCase, SellProductUseCase>();

builder.Services.AddTransient<IRecordTransactionUseCase, RecordTransactionUseCase>();
builder.Services.AddTransient<IGetTodayTransactionsUseCase, GetTodayTransactionsUseCase>();
builder.Services.AddTransient<ISearchTransactionsUseCase, SearchTransactionsUseCase>();


>>>>>>> 6979bea (login)
var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

<<<<<<< HEAD
=======
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
>>>>>>> 6979bea (login)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

