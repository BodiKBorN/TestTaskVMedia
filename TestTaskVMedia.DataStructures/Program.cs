using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestTaskVMedia.DataStructures;

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var services = new ServiceCollection()
    .AddOptions()
    .AddDbContext<RailroadTicketsContext>()
    .AddSingleton<IConfiguration>(config)
    .BuildServiceProvider();

services.GetService<RailroadTicketsContext>();