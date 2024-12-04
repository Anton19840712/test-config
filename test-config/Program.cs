using test_config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

try
{
	// ���� � ���������������� ������
	string[] configPaths = new[]
	{
				@"test-config\appsettings.json",
				@"test-appsettings-location\appsettings.json"
			};

	// �������� ������������
	var configuration = ConfigurationLoader.LoadConfiguration(configPaths);

	// ����� ����������
	Console.WriteLine($"Test �� test-config: {configuration["Test1"]}");
	Console.WriteLine($"Test �� test-appsettings-location: {configuration["Test2"]}");
}
catch (Exception ex)
{
	Console.WriteLine($"������: {ex.Message}");
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
