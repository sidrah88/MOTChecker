using System;
using System.Text.Json.Serialization;

namespace VehicleHistoryChecker.Pages
{
    public class MOT
    {
        [JsonConverter(typeof(ConvertDateTime))]
        [JsonPropertyName("expiryDate")]
        public DateTime ExpiryDate { get; set; }

        [JsonPropertyName("odometerValue")]
        public string OdometerValue { get; set; }
    }
}
