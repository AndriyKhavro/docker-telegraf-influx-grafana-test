using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Nest;

namespace Homework03;

[Route("api/products")]
[ApiController]
public class ProductController : ControllerBase
{
    private const string DatabaseName = "Homework03";
    private const string CollectionName = "products";
    private readonly IMongoClient _mongoClient;
    private readonly IElasticClient _elasticClient;

    public ProductController(IMongoClient mongoClient, IElasticClient elasticClient)
    {
        _mongoClient = mongoClient;
        _elasticClient = elasticClient;
    }

    [HttpGet]
    public async Task<IReadOnlyCollection<Product>> SearchProducts([FromQuery] string query)
    {
        var searchResponse = await _elasticClient.SearchAsync<Product>(s => s
            .Query(q => q
                .Wildcard(m => m
                    .Field(f => f.Name)
                    .Value($"*{query}*")
                )
            )
        );

        return searchResponse.Documents;
    }

    [HttpGet("{id}")]
    public async Task<Product?> GetProductById(string id)
    {
        var database = _mongoClient.GetDatabase(DatabaseName);
        var collection = database.GetCollection<Product>(CollectionName);
        var product = await collection.Find(p => p.Id == id).FirstOrDefaultAsync();
        return product;
    }

    [HttpPost]
    public async Task<Product> CreateProduct(CreateProductRequest createProductRequest)
    {
        var product = new Product { Name = createProductRequest.Name, Price = createProductRequest.Price };

        var database = _mongoClient.GetDatabase(DatabaseName);
        var collection = database.GetCollection<Product>(CollectionName);
        await collection.InsertOneAsync(product);

        await _elasticClient.IndexDocumentAsync(product);
        return product;
    }

    [HttpPut]
    public async Task<Product> UpdateProduct(Product product)
    {
        var database = _mongoClient.GetDatabase(DatabaseName);
        var collection = database.GetCollection<Product>(CollectionName);

        var exists = await collection.Find(p => p.Id == product.Id).AnyAsync();
        if (exists)
        {
            await collection.ReplaceOneAsync(p => p.Id == product.Id, product);
        }
        else
        {
            await collection.InsertOneAsync(product);
        }

        await _elasticClient.IndexDocumentAsync(product);

        return product;
    }
}

public class Product
{
    [BsonId]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [BsonElement("name")] 
    public required string Name { get; init; }

    [BsonElement("price")]
    public required decimal Price { get; init; }

    [BsonElement("created")]
    public DateTime Created { get; set; } = DateTime.UtcNow;
}

public record CreateProductRequest(string Name, decimal Price)
{
}
