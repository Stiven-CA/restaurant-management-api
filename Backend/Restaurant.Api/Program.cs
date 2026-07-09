using Restaurant.Application.UseCases.Dishs;
using Restaurant.Application.UseCases.Tables;
using Restaurant.Application.UseCases.Users;
using Restaurant.Application.UseCases.Orders;
using Restaurant.Application.UseCases.OrderDetails;
using Restaurant.Application.UseCases.Reservations;
using Restaurant.Application.UseCases.SalesReports;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<AddDish>();
builder.Services.AddScoped<RemoveDish>();
builder.Services.AddScoped<AddTable>();
builder.Services.AddScoped<RemoveTable>();
builder.Services.AddScoped<GetAvailableTables>();
builder.Services.AddScoped<Login>();
builder.Services.AddScoped<RegisterUser>();
builder.Services.AddScoped<OpenOrder>();
builder.Services.AddScoped<AddItemOrder>();
builder.Services.AddScoped<RecordPayment>();
builder.Services.AddScoped<ReservationTable>();
builder.Services.AddScoped<CancelReservation>();
builder.Services.AddScoped<SalesReport>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
