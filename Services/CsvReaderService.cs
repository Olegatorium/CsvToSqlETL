using CsvHelper;
using DbContext.Entities;
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
    public class CsvReaderService : ICsvReaderService
    {
        private readonly string _csvFilePath;

        public CsvReaderService(IConfiguration configuration)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;

            string projectRoot = Path.GetFullPath(Path.Combine(basePath, @"..\..\.."));

            string relativePath = configuration["FilePath"];

            _csvFilePath = Path.Combine(projectRoot, relativePath);
        }

        public List<RideData> ReadCsv()
        {
            CheckFileSize(_csvFilePath);

            var data = new List<RideData>();

            using (var reader = new StreamReader(_csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>().ToList();

                foreach (var record in records)
                {
                    var rideData = new RideData
                    {
                        TpepPickupDatetime = ParseDate(record.tpep_pickup_datetime),
                        TpepDropoffDatetime = ParseDate(record.tpep_dropoff_datetime),
                        PassengerCount = ParseInt(record.passenger_count),
                        TripDistance = ParseDecimal(record.trip_distance),
                        StoreAndFwdFlag = ParseStoreAndFwdFlag(record.store_and_fwd_flag),
                        PULocationID = ParseInt(record.PULocationID),
                        DOLocationID = ParseInt(record.DOLocationID),
                        FareAmount = ParseDecimal(record.fare_amount),
                        TipAmount = ParseDecimal(record.tip_amount)
                    };

                    data.Add(rideData);
                }
            }

            return data;
        }

        private void CheckFileSize(string filePath)
        {
            const int MaxFileSizeInMb = 100; 
            var fileInfo = new FileInfo(filePath);

            if (fileInfo.Length > MaxFileSizeInMb * 1024 * 1024)
            {
                throw new Exception($"File is too large to process. Maximum allowed size is {MaxFileSizeInMb} MB.");
            }
        }


        private DateTime ParseDate(string date)
        {
            if (DateTime.TryParse(date?.Trim(), out DateTime result))
            {
                TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

                DateTime estDateTime = TimeZoneInfo.ConvertTime(result, estTimeZone, TimeZoneInfo.Utc);

                return estDateTime;
            }

            return DateTime.MinValue;
        }

        private int ParseInt(string value)
        {
            return int.TryParse(value?.Trim(), out int result) ? result : 0;
        }

        private decimal ParseDecimal(string value)
        {
            return decimal.TryParse(value?.Trim(), out decimal result) ? result : 0m;
        }

        private string ParseStoreAndFwdFlag(string flag)
        {
            return flag?.Trim() == "Y" ? "Yes" : "No";
        }
    }
}
