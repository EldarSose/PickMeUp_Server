using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PickMeUp;
using PickMeUp.Core.Entities;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Repository.Repositories;
using PickMeUp.Service.Interfaces;
using PickMeUp.Service.Services;

var AllowAll = "AllowAll";

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false)
    .Build();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowAll, policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var konekcijskiString = builder.Configuration.GetConnectionString("DefaultConnection");

var optionsBuilder = builder.Services.AddDbContext<PickMeUpDbContext>(
	dbContextOpcije => dbContextOpcije
	.UseSqlServer(konekcijskiString, b => b.MigrationsAssembly("PickMeUp.Repository")));

//Repository
builder.Services.AddScoped(typeof(IGenericRepository<,>), typeof(GenericRepository<,>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDriverRatingsRepository, DriverRatingsRepository>();
builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderStatusRepository, OrderStatusRepository>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IReportTypeRepository, ReportTypeRepository>();
builder.Services.AddScoped<IReviewsRepository, ReviewsRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IRoleUserRepository, RoleUserRepository>();
builder.Services.AddScoped<IShiftRepository, ShiftRepository>();
builder.Services.AddScoped<ITaxiContactRepository, TaxiContactRepository>();
builder.Services.AddScoped<ITaxiDriverCarRepository, TaxiDriverCarRepository>();
builder.Services.AddScoped<ITaxiRepository, TaxiRepository>();
builder.Services.AddScoped<IUserAccountRepository, UserAccountRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

//Service
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IDriverRatingsService, DriverRatingsService>();
builder.Services.AddScoped<IGenderService, GenderService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderStatusService, OrderStatusService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportTypeService, ReportTypeService>();
builder.Services.AddScoped<IReviewsService, ReviewsService>();
builder.Services.AddScoped<IRolesService, RolesService>();
builder.Services.AddScoped<IRoleUserService, RoleUserService>();
builder.Services.AddScoped<IShiftService, ShiftService>();
builder.Services.AddScoped<ITaxiContactService, TaxiContactService>();
builder.Services.AddScoped<ITaxiDriverCarService, TaxiDriverCarService>();
builder.Services.AddScoped<ITaxiService, TaxiService>();
builder.Services.AddScoped<IUserAccountService, UserAccountService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
	var dataContext = scope.ServiceProvider.GetRequiredService<PickMeUpDbContext>();
	if(!dataContext.Database.EnsureCreated())
	{ 
		var conn = dataContext.Database.GetConnectionString();
	
		dataContext.Database.Migrate();


        //new SetupService().InsertData(dataContext);
	}
    var g = new Gender
    {
        description = "M",
        isDeleted = false
    };

    var gf = new Gender
    {
        description = "F",
        isDeleted = false
    };

    dataContext.Genders.Add(g);

    dataContext.Genders.Add(gf);

    dataContext.SaveChanges();



    //new SetupService().Init(dataContext);



}

app.Run();
