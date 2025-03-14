using DbContext.Entities;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataProcessingService : IDataProcessingService
    {
        public (List<RideData> uniqueData, List<RideData> duplicateData) SeparateDuplicatesFromUniqueData(List<RideData> data)
        {
            var uniqueData = new List<RideData>();
            var duplicateData = new List<RideData>();

            var seen = new HashSet<string>(); 

            foreach (var ride in data)
            {
                var key = $"{ride.TpepPickupDatetime}-{ride.TpepDropoffDatetime}-{ride.PassengerCount}"; 

                if (seen.Contains(key))
                {
                    duplicateData.Add(ride); 
                }
                else
                {
                    seen.Add(key); 
                    uniqueData.Add(ride); 
                }
            }

            return (uniqueData, duplicateData);
        }
    }
}
