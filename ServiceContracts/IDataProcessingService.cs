using DbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IDataProcessingService
    {
        (List<RideData> uniqueData, List<RideData> duplicateData) SeparateDuplicatesFromUniqueData(List<RideData> data);
    }

}
