namespace test_config
{
	public static class ConfigurationLoader
	{
		public static IConfiguration LoadConfiguration(string[] relativePaths)
		{
			// Базовый путь: текущий каталог запуска приложения
			string basePath = AppDomain.CurrentDomain.BaseDirectory;

			// Путь к корневой директории проекта
			string rootPath = Path.Combine(basePath, @"..\..\..\..\");

			var builder = new ConfigurationBuilder();

			foreach (var relativePath in relativePaths)
			{
				// Формируем абсолютный путь
				string fullPath = Path.GetFullPath(Path.Combine(rootPath, relativePath));

				// Проверяем наличие файла
				if (!File.Exists(fullPath))
				{
					throw new FileNotFoundException($"Файл конфигурации не найден: {fullPath}");
				}

				// Добавляем файл в билд конфигурации
				builder.AddJsonFile(fullPath, optional: false, reloadOnChange: false);
			}

			// Собираем и возвращаем IConfiguration
			return builder.Build();
		}
	}
}
