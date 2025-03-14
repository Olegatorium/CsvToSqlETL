using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DbContext.Entities
{
    public class RideData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime TpepPickupDatetime { get; set; }
        public DateTime TpepDropoffDatetime { get; set; }
        public int PassengerCount { get; set; }
        public decimal TripDistance { get; set; }
        public string StoreAndFwdFlag { get; set; }
        public int PULocationID { get; set; }
        public int DOLocationID { get; set; }
        public decimal FareAmount { get; set; }
        public decimal TipAmount { get; set; }

        [NotMapped]
        public int TripTimeInMinutes => (int)(TpepDropoffDatetime - TpepPickupDatetime).TotalMinutes;
    }

}
