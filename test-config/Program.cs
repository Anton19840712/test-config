using test_config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

try
{
	// Пути к конфигурационным файлам
	string[] configPaths = new[]
	{
				@"test-config\appsettings.json",
				@"test-appsettings-location\appsettings.json"
			};

	// Загрузка конфигурации
	var configuration = ConfigurationLoader.LoadConfiguration(configPaths);

	// Вывод параметров
	Console.WriteLine($"Test из test-config: {configuration["Test1"]}");
	Console.WriteLine($"Test из test-appsettings-location: {configuration["Test2"]}");
}
catch (Exception ex)
{
	Console.WriteLine($"Ошибка: {ex.Message}");
}

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
