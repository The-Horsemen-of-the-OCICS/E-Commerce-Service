using ecommerceapp.models;
using ecommerceapp.services;

var  AllowSpecificOrigins = "_allowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DatabaseSettings>(
                builder.Configuration.GetSection(nameof(DatabaseSettings)));
var options = builder.Configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();

// Add services for DI
builder.Services.AddSingleton<DatabaseSettings>(options);
builder.Services.AddSingleton<ItemService>();
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<CategoryService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<ResponseService>();
builder.Services.AddSingleton<QuestionService>();


// Swagger options
builder.Services.AddSwaggerGen(options => options.SwaggerGeneratorOptions.DescribeAllParametersInCamelCase = true);


// COR
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificOrigins,
                      builder =>
                      {
                          builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
