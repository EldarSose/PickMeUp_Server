using Microsoft.EntityFrameworkCore;
using PickMeUp.Repository;
using PickMeUp.Repository.Interfaces;
using PickMeUp.Repository.Repositories;
using PickMeUp.Service.Interfaces;
using PickMeUp.Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var konekcijskiString = builder.Configuration.GetConnectionString("DefaultConnection");

var optionsBuilder = builder.Services.AddDbContext<PickMeUpDbContext>(
	dbContextOpcije => dbContextOpcije
	.UseSqlServer(konekcijskiString));

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

app.Run();
