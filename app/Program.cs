using MongoDB.Driver;
using Nest;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var mongoConnectionString = builder.Configuration.GetConnectionString("MongoDB");
var elasticConnectionSettings = new ConnectionSettings(new Uri(builder.Configuration.GetConnectionString("Elasticsearch")!))
    .DefaultIndex("products")
    .ThrowExceptions();

builder.Services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoConnectionString));
builder.Services.AddSingleton<IElasticClient>(_ => new ElasticClient(elasticConnectionSettings));

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();

