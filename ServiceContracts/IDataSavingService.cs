using DbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface IDataSavingService
    {
        Task SaveDataBulkAsync(List<RideData> data);
        Task SaveDuplicatesToFileAsync(List<RideData> duplicates);
    }

}
