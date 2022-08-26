using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace GetLocationByLatLon
{
   public class GeocodeLocationIQ
    {
        private bool _UseApiKey;

        private string _GeocodeApiUrl = "https://us1.locationiq.com/v1/reverse.php";
        private string _ApiKey;
        public GeocodeLocationIQ(bool useApiKey = false)
        {
            _GeocodeApiUrl = ConfigurationManager.AppSettings["LocationIQUri"];

            if (useApiKey)
            {
                _UseApiKey = true;
                _ApiKey = ConfigurationManager.AppSettings["LocationIQApiKey"];
            }
        }
        public string GetRequestUrl(double lat, double lng, GeocodeLocationType locationType)
        {
            string requestUrl = GetRequestString(lat, lng, locationType);

            if (_UseApiKey)
            {
                requestUrl += "&key=" + _ApiKey + "&format=json";
            }

            return requestUrl;
        }
        private string GetRequestString(double lat, double lng, GeocodeLocationType locationType)
        {
            if (GeocodeLocationType.ROOFTOP.Equals(locationType))
            {
                return String.Format("{0}?lat={1}&lon={2}", _GeocodeApiUrl, lat.ToString("F6"), lng.ToString("F6"));
            }

            return String.Format("{0}?lat={1}&lon={2}", _GeocodeApiUrl, lat.ToString("F6"), lng.ToString("F6"));
        }
    }
}
