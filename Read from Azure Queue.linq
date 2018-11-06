<Query Kind="Program">
  <NuGetReference>WindowsAzure.Storage</NuGetReference>
  <Namespace>Microsoft.WindowsAzure.Storage</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

void Main()
{
	var connectionString = "";
	var queuename = "";
	
	
	var storageAccount = CloudStorageAccount.Parse(connectionString);
	var queueClient = storageAccount.CreateCloudQueueClient();
	var queue = queueClient.GetQueueReference(queuename);
	queue.CreateIfNotExists();
	
	while (true)
	{
		var update = queue.GetMessage(TimeSpan.FromMinutes(2));
		if (update == null)
		{
			continue;
		}
		update.AsString.Dump();
		
	}
}


// Define other methods and classes here
