<Query Kind="Statements">
  <NuGetReference>Microsoft.Azure.NotificationHubs</NuGetReference>
  <Namespace>Microsoft.Azure.NotificationHubs</Namespace>
</Query>

string CONNECTION_STRING = "{notificationhub connectionstring}";
string HUB_NAME = "{hubname}";
var TAG = "tag";
var PUSHREGID = "pushRegId";

var hub = NotificationHubClient.CreateClientFromConnectionString(CONNECTION_STRING, HUB_NAME);

var allRegistrations = await hub.GetAllRegistrationsAsync(0);
var continuationToken = allRegistrations.ContinuationToken;
var registrationDescriptionsList = new List<RegistrationDescription>(allRegistrations);
while (!string.IsNullOrWhiteSpace(continuationToken))
{
	var otherRegistrations = await hub.GetAllRegistrationsAsync(continuationToken, 0);
	registrationDescriptionsList.AddRange(otherRegistrations);
	continuationToken = otherRegistrations.ContinuationToken;
}

registrationDescriptionsList.Dump("All");

var reg = registrationDescriptionsList.ToList().Where(dl => dl.Tags.Any(t => t.Contains(TAG)));
reg.Dump(TAG);

var regs = registrationDescriptionsList.OfType<AppleRegistrationDescription>().Where(dl => dl.RegistrationId == PUSHREGID);
regs.Dump(PUSHREGID);