using AleRoe.HomematicIpApi;

namespace HomeaticIpConsole
{
    internal class Program
    {

        static string accessPoint = "3014F711A00003D709B034F7";
        static string authToken = "F321A85FF95C4BB213B20DC0E005EAC6F649CB14A73A4A382335FB3CCB4DC3C8";
        static async Task Main(string[] args)
        {
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Canceling...");
                cts.Cancel();
                e.Cancel = true;
            };


            var tcs = new TaskCompletionSource();

            var config = new HomematicIpConfiguration() { AccessPointId = accessPoint, AuthToken = authToken };
            var client = new HomematicIpClient(config);

            client.OnDisconnect += (s, e) => Console.WriteLine("Disconnecting " + e.DisconnectionInfo.Type);
            client.OnReconnect += (s, e) => Console.WriteLine("Reconnecting " + e.ReconnectionInfo.Type);

            await client.InitializeAsync(CancellationToken.None);
            client.PushEventRecieved.Subscribe(Console.WriteLine);
            
            
            Console.WriteLine("Wait for Cancel");

            try
            {
                await tcs.Task.WaitAsync(cts.Token).ConfigureAwait(false);
            }
            catch (Exception)
            {
            }
            Console.WriteLine("Disposing...");
            client.Dispose();
            Console.WriteLine("End");
        }

        
    }
}