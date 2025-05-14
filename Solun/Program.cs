using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Extensions.NETCore.Setup;
using Database.Mappers;
using Database.Mappers.Interfaces;
using Database.Repositories;
using Database.Repositories.Interfaces;
using Solun.Services;
using Solun.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());

//builder.Services.AddDefaultAWSOptions(
//	new AWSOptions
//	{
//		Region =  RegionEndpoint.GetBySystemName("us-west-2"),
//	});
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddSingleton<ISolunDynamoDb, SolunDynamoDb>();
builder.Services.AddSingleton<IWatchService, WatchService>();
builder.Services.AddSingleton<IMapper, Mapper>();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var env = app.Environment; // Add this line to define 'env' in the current context

app.Use(async (context, next) =>
{
	// Allow API calls and static files to be handled normally
	if (context.Request.Path.StartsWithSegments("/api") ||
		Path.HasExtension(context.Request.Path))
	{
		await next();
		return;
	}

	var indexPath = Path.Combine(app.Environment.WebRootPath ?? "wwwroot", "index.html");
	context.Response.ContentType = "text/html";
	await context.Response.SendFileAsync(indexPath);
});

app.Run();



//builder.Services.AddSingleton<IAmazonDynamoDB>(sp =>
//{
//	var config = new AmazonDynamoDBConfig
//	{
//		RegionEndpoint = Amazon.RegionEndpoint.USEast1 // Set your desired region
//	};
//	return new AmazonDynamoDBClient(config);
//});