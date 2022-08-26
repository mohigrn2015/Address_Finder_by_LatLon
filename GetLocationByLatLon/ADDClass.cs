using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Text;

namespace GetLocationByLatLon
{
    public class ResolvedAddress : FastPriorityQueueNode
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
        public double ResponsedLat { get; set; }
        public double ResponsedLng { get; set; }
        public double Speed { get; set; }

        public string FormattedAddress { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public GeocodeLocationType LocationType { get; set; }


        public object UserState { get; set; }

        public string RequestUrl { get; set; }
        public string ResponseData { get; set; }

        public GeocodeStatus Status { get; set; }
        public string StatusMessage { get; set; }

        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }
    }
    public class GeocodeResponseResult
    {
        public double lat { get; set; }
        public double lon { get; set; }

        public GeocodeAddress address { get; set; }
        public string display_name { get; set; }
    }
    public class GeocodeAddress
    {
        //[{
        //    "address": {
        //      "building": "Keari Plaza",
        //      "road": "Satmasjid Road",
        //      "neighbourhood": "Dhanmondi R/A",
        //      "suburb": "Dhanmondi R/A",
        //      "city": "Dhaka",
        //      "state": "Dhaka Division",
        //      "postcode": "1209",
        //      "country": "Bangladesh",
        //      "country_code": "bd"
        //    }
        //}]

        public string building { get; set; }
        public string road { get; set; }
        public string neighbourhood { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
    }

    public class TruckMoveModel : FastPriorityQueueNode
    {
        public int AddressKey { get; set; }

        public int TruckMoveId { get; set; }

        public double Lat { get; set; }
        public double Lng { get; set; }
        public double Speed { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        public bool IsStateMissing { get; set; }
        public float Priority { get; set; }
    }

    public class GeocodeLocationType
    {
        private string _LocationType { get; set; }


        public GeocodeLocationType(string locationType)
        {
            _LocationType = locationType;
        }

        public override string ToString()
        {
            return _LocationType;
        }

        public override bool Equals(object locationType)
        {
            return this.ToString() == locationType.ToString();
        }

        public static bool operator ==(GeocodeLocationType typeA, GeocodeLocationType typeB)
        {
            return typeA.ToString() == typeB.ToString();
        }

        public static bool operator !=(GeocodeLocationType typeA, GeocodeLocationType typeB)
        {
            return typeA.ToString() != typeB.ToString();
        }

        public static GeocodeLocationType NONE = new GeocodeLocationType("NONE");
        public static GeocodeLocationType ROOFTOP = new GeocodeLocationType("ROOFTOP");
        public static GeocodeLocationType RANGE_INTERPOLATED = new GeocodeLocationType("RANGE_INTERPOLATED");
        public static GeocodeLocationType GEOMETRIC_CENTER = new GeocodeLocationType("GEOMETRIC_CENTER");
        public static GeocodeLocationType APPROXIMATE = new GeocodeLocationType("APPROXIMATE");
    }

    public class GeocodeStatus
    {
        private string _Status { get; set; }

        public GeocodeStatus(string status)
        {
            _Status = status;
        }

        public override string ToString()
        {
            return _Status;
        }

        public override bool Equals(object status)
        {
            return this.ToString() == status.ToString();
        }

        public static bool operator ==(GeocodeStatus statusA, GeocodeStatus statusB)
        {
            return statusA.ToString() == statusB.ToString();
        }

        public static bool operator !=(GeocodeStatus statusA, GeocodeStatus statusB)
        {
            return statusA.ToString() != statusB.ToString();
        }

        public static GeocodeStatus OK = new GeocodeStatus("OK");
        public static GeocodeStatus ZERO_RESULTS = new GeocodeStatus("ZERO_RESULTS");
        public static GeocodeStatus OVER_QUERY_LIMIT = new GeocodeStatus("OVER_QUERY_LIMIT");
        public static GeocodeStatus REQUEST_DENIED = new GeocodeStatus("REQUEST_DENIED");
        public static GeocodeStatus INVALID_REQUEST = new GeocodeStatus("INVALID_REQUEST");
        public static GeocodeStatus UNKNOWN_ERROR = new GeocodeStatus("UNKNOWN_ERROR");

        public static GeocodeStatus WEBCLIENT_EXCEPTION = new GeocodeStatus("WEBCLIENT_EXCEPTION");
    }

    /* Internal Classes */
    public class LatLng
    {
        public double Lat { get; set; }
        public double Lng { get; set; }


        public object UserState { get; set; }
        public string RequestUrl { get; set; }
        public DateTime RequestTime { get; set; }
        public DateTime ResponseTime { get; set; }
        public GeocodeLocationType RequestLocationType { get; set; }
    }

    //internal class GeocodeResponse
    //{
    //    /*
    //    [JsonProperty("status")]
    //    public string jsonStatus { get; set; }

    //    private GeocodeStatus _Status;
    //    public GeocodeStatus Status {
    //        get
    //        {
    //            if (_Status == null)
    //            {
    //                _Status = new GeocodeStatus(jsonStatus);
    //                return _Status;
    //            }
    //            else
    //            {
    //                return _Status;
    //            }

    //        }
    //        set
    //        {
    //            _Status = value;
    //        }
    //    }
    //    */

    //    public string error_message { get; set; }
    //    public string status { get; set; }
    //    public List<GeocodeResult> results { get; set; }

    //    //public GeocodeResponse()
    //    //{
    //    //    results = new List<GeocodeResult>();
    //    //}
    //}

    internal class GeocodeResult
    {
        public List<GeocodeAddressComponenet> address_components { get; set; }
        public string formatted_address { get; set; }
        public Geometry geometry { get; set; }

        //public GeocodeResult()
        //{
        //    address_components = new List<GeocodeAddressComponenet>();
        //}
    }

    internal class GeocodeAddressComponenet
    {
        public string long_name { get; set; }
        public string short_name { get; set; }
        public List<string> types { get; set; }

        //public GeocodeAddressComponenet()
        //{
        //    types = new List<string>();
        //}
    }

    internal class Geometry
    {
        public Location location { get; set; }
        public string location_type { get; set; }
        /*
        public GeocodeLocationType location_type { get; set; }
        */
    }

    internal class Location
    {
        public double lat { get; set; }
        public double lng { get; set; }
    }
}
