<Query Kind="Statements">
  <NuGetReference>Microsoft.Azure.Devices.Client</NuGetReference>
  <Namespace>Microsoft.Azure.Devices.Client</Namespace>
</Query>

var cs = "";
var device = DeviceClient.CreateFromConnectionString(cs, TransportType.Mqtt);

while (true)
{
	Message receivedMessage = await device.ReceiveAsync();
	if (receivedMessage == null) continue;

	Console.ForegroundColor = ConsoleColor.Yellow;
	Console.WriteLine("Received message: {0}",
	Encoding.ASCII.GetString(receivedMessage.GetBytes()));
	Console.ResetColor();

	await device.CompleteAsync(receivedMessage);
}