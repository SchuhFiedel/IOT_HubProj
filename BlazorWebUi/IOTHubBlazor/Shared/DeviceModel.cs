using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace IOTHubBlazor.Shared
{
    public class DeviceModel
    {
        public Guid? DeviceId { get; set; }
        [Required]
        public string DeviceName { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$")]
        public string StaticIPAddress { get; set; } = string.Empty;
    }
}
