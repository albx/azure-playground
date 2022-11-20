using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System.Threading.Tasks;

namespace AzureSignalRService.BlazorWasmChat.Api
{
    public static class Function1
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo Negotiate(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "chat")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("sendMessage")]
        public static async Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest request,
            [SignalR(HubName = "chat")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            var chatMessage = await request.ReadFromJsonAsync<ChatMessage>();

            await signalRMessages.AddAsync(new SignalRMessage
            {
                Target = "newMessage",
                Arguments = new[] { chatMessage.Username, chatMessage.Message }
            });
        }

        record ChatMessage(string Username, string Message);
    }
}
