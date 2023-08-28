using IOTHubBlazor.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Linq;

namespace IOTHubBlazor.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WebhookController : ControllerBase
    {
        private static List<DeviceModel> connectedDevices = new List<DeviceModel>();

        private readonly ILogger<WebhookController> _logger;

        public WebhookController(ILogger<WebhookController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<DeviceModel> RegisterDevice([FromBody] DeviceModel device)
        {
            if(device.DeviceId == null && !connectedDevices.Exists(x => x.StaticIPAddress == device.StaticIPAddress) )
            {
                device.DeviceId = Guid.NewGuid();
                connectedDevices.Add(device);
            }
            else if(device.DeviceId != null && !connectedDevices.Exists(x => x.DeviceId == device.DeviceId || x.StaticIPAddress == device.StaticIPAddress))
            {
                connectedDevices.Add(device);
            }
            else
            {
                throw new HttpRequestException(message: "A similar device entry already exists", inner: new Exception(), statusCode: System.Net.HttpStatusCode.Conflict);
            }

            string json = JsonSerializer.Serialize(connectedDevices, new JsonSerializerOptions() { WriteIndented = true});
            Console.WriteLine(json);
            return device;
        }
    }
}