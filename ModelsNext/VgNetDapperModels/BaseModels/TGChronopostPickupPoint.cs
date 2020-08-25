using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace VgNetDapperModels.BaseModels
{
    [Table("TGChronopostPickupPoints")]
    public class TGChronopostPickupPoint
    {
        [ExplicitKey]
        public int Number { get; set; }
        public string Country { get; set; }

        public string StoreNumber { get; set; }
        public string MorningOpenHourD { get; set; }
        public string PostalCode { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string AfterNoonCloseHourD { get; set; }
        public string MorningCloseHour6 { get; set; }
        public string AfterNoonOpenHour6 { get; set; }
        public string MorningCloseHour4 { get; set; }
        public string MorningCloseHour5 { get; set; }
        public string MorningCloseHour2 { get; set; }
        public string AfterNoonOpenHour2 { get; set; }
        public string MorningCloseHour3 { get; set; }
        public string AfterNoonOpenHour3 { get; set; }
        public string AfterNoonOpenHour4 { get; set; }
        public string AfterNoonOpenHour5 { get; set; }
        public string MorningOpenHour6 { get; set; }
        public string AfterNoonCloseHourS { get; set; }
        public string PostalCodeLocation { get; set; }
        public string MorningOpenHour2 { get; set; }
        public string DoorNumber { get; set; }
        public string MorningOpenHour3 { get; set; }
        public string MorningOpenHour4 { get; set; }
        public string MorningOpenHour5 { get; set; }
        public string DeliverySaturday { get; set; }
        public string ChangeDate { get; set; }
        public string Email { get; set; }
        public string AfterNoonOpenHourD { get; set; }
        public string Address { get; set; }
        public string RowChange { get; set; }
        public string MorningCloseHourS { get; set; }
        public string AfterNoonOpenHourS { get; set; }
        public string DeliverySunday { get; set; }
        public string AfterNoonCloseHour3 { get; set; }
        public string AfterNoonCloseHour2 { get; set; }
        public string PhoneNumber { get; set; }
        public string MorningOpenHourS { get; set; }
        public string AfterNoonCloseHour6 { get; set; }
        public string AfterNoonCloseHour5 { get; set; }
        public string AfterNoonCloseHour4 { get; set; }
        public string Name { get; set; }
        public string MorningCloseHourD { get; set; }
        public string Status { get; set; }
    }
}
