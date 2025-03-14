using CsvHelper;
using DbContext.Entities;
using EFCore.BulkExtensions;
using Entities;
using Microsoft.Extensions.Configuration;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Services
{
    public class CsvImportService : ICsvImportService
    {
        private readonly ICsvReaderService _csvReaderService;
        private readonly IDataProcessingService _dataProcessingService;
        private readonly IDataSavingService _dataSavingService;

        public CsvImportService(
            ICsvReaderService csvReaderService,
            IDataProcessingService dataProcessingService,
            IDataSavingService dataSavingService)
        {
            _csvReaderService = csvReaderService;
            _dataProcessingService = dataProcessingService;
            _dataSavingService = dataSavingService;
        }

        public async Task ProcessData()
        {
            var data = _csvReaderService.ReadCsv();
            var (uniqueData, duplicateData) = _dataProcessingService.SeparateDuplicatesFromUniqueData(data);
            await _dataSavingService.SaveDataBulkAsync(uniqueData);
            await _dataSavingService.SaveDuplicatesToFileAsync(duplicateData);
        }
    }
}

