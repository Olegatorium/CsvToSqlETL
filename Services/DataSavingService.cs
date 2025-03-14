using CsvHelper;
using DbContext.Entities;
using EFCore.BulkExtensions;
using Entities;
using Microsoft.Extensions.Configuration;
using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DataSavingService : IDataSavingService
    {
        private readonly ApplicationDbContext _db;
        private readonly string _projectRoot;

        public DataSavingService(ApplicationDbContext db, IConfiguration configuration)
        {
            _db = db;

            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            _projectRoot = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));
        }

        public async Task SaveDataBulkAsync(List<RideData> data)
        {
            if (data.Any())
            {
                await _db.BulkInsertAsync(data);
                Console.WriteLine($"{data.Count} records inserted successfully!");
            }
        }

        public async Task SaveDuplicatesToFileAsync(List<RideData> duplicates)
        {
            if (duplicates.Any())
            {
                var filePath = Path.Combine(_projectRoot, "Resources", "duplicates.csv");
                using (var writer = new StreamWriter(filePath))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    await csv.WriteRecordsAsync(duplicates);
                }
                Console.WriteLine($"Duplicates saved to {filePath}");
            }
        }
    }
}
