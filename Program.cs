using ecommerceapp.services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services for DI
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
    options.AddDefaultPolicy(
        builder =>
        {
            builder.WithOrigins("*");
            builder.WithMethods("POST");
            builder.WithHeaders("Content-Type");
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
