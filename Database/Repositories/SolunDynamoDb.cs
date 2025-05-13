using Amazon.DynamoDBv2;
//using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Database.Repositories.Interfaces;
using Database.DatabaseModels;
using Amazon.DynamoDBv2.Model;
//using Amazon.DynamoDBv2.Model;

namespace Database.Repositories
{
	public class SolunDynamoDb : ISolunDynamoDb
	{
		private readonly DynamoDBContext context;
		private readonly IAmazonDynamoDB amazonDynamoDb;
		private const string tableName = "Solun";
		IDynamoDBContextBuilder contextBuilder;

		public SolunDynamoDb(IAmazonDynamoDB amazonDynamoDb)
		{
			contextBuilder = new DynamoDBContextBuilder();
			context = contextBuilder.WithDynamoDBClient(()=>amazonDynamoDb).Build();
			this.amazonDynamoDb = amazonDynamoDb;
			//this.context = new DynamoDBContext(amazonDynamoDb);
		}

		public async Task<IEnumerable<WatchDb>> GetAllWatches()
		{
			//var request = new ScanRequest(tableName)
			//{

			//};
			//var scanResponse =  await amazonDynamoDb.ScanAsync(request).ConfigureAwait(false);
			return await context.ScanAsync<WatchDb>(new List<ScanCondition>()).GetRemainingAsync().ConfigureAwait(false);
			//return await amazonDynamoDb.ScanAsync<WatchDb>(new List<ScanCondition>()).GetRemainingAsync();
		}

		public async Task<int> GetNextUserIdAsync()
		{
			var request = new UpdateItemRequest
			{
				TableName = "Solun_User_Counters", // Table that stores your counter
				Key = new Dictionary<string, AttributeValue>
				{
					["PK"] = new AttributeValue { S = "Counter_UserId" }
				},
				UpdateExpression = "ADD CurrentValue :incr",
				ExpressionAttributeValues = new Dictionary<string, AttributeValue>
				{
					[":incr"] = new AttributeValue { N = "1" }
				},
				ReturnValues = "UPDATED_NEW"
			};

			var response = await amazonDynamoDb.UpdateItemAsync(request);
			return int.Parse(response.Attributes["CurrentValue"].N);
		}
		public async Task AddWatch(WatchDb watchDb)
		{
			await context.SaveAsync(watchDb);
		}
	}
}
