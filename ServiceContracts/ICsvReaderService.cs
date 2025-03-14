using DbContext.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    public interface ICsvReaderService
    {
        List<RideData> ReadCsv();
    }
}
