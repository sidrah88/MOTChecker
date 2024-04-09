using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VehicleHistoryChecker.Pages
{
    public class VehicleInformation
    {
        [JsonPropertyName("make")]
        public string Make { get; set; }

        [JsonPropertyName("model")]
        public string Model { get; set; }

        [JsonPropertyName("primaryColour")]
        public string Colour { get; set; }

        [JsonPropertyName("motTests")]
        public List<MOT> MOTTests { get; set; }

        public DateTime ExpiryDateMOT
        {
            get
            {
                if (MOTTests.Count > 0 && MOTTests != null)
                {
                    // This checks for the most recent MOT test time and date
                    DateTime recentExpiryDate = DateTime.MinValue;
                    foreach (var i in MOTTests)
                    {
                        if (i.ExpiryDate > recentExpiryDate)
                            recentExpiryDate = i.ExpiryDate;
                    }
                    return recentExpiryDate;
                }
                else
                {
                    return DateTime.MinValue;
                }
            }
        }

        public int MOTlastMileage
        {
            get
            {
                if (MOTTests.Count > 0 && MOTTests != null)
                {
                    // This is finding the recent mileage value from the MOT test
                    int recentMileage = 0;
                    foreach (var i in MOTTests)
                    {
                        if (int.TryParse(i.OdometerValue, out int mileage))
                        {
                            if (mileage > recentMileage)
                                recentMileage = mileage;
                        }
                    }
                    return recentMileage;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
}
