<Query Kind="Statements">
  <NuGetReference>Microsoft.Azure.NotificationHubs</NuGetReference>
  <Namespace>Microsoft.Azure.NotificationHubs</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
</Query>

string CONNECTION_STRING = "{notificationhub connectionstring}";
string HUB_NAME = "{hubname}";
string TAG = "tag";
string TEXT = "test";

var payload = JsonConvert.SerializeObject(new { notification = new { body = TEXT } });

var client = NotificationHubClient.CreateClientFromConnectionString(CONNECTION_STRING, HUB_NAME);
var result = client.SendGcmNativeNotificationAsync(payload, TAG).Result;

var hl = new Hyperlinq(async () =>
{
	var message = await client.GetNotificationOutcomeDetailsAsync(result.NotificationId);
	result.Dump();
}, result.NotificationId);

result.Dump(TAG);

hl.Dump();




