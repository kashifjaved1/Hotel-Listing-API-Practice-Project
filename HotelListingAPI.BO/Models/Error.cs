using Newtonsoft.Json;

namespace HotelListingAPI.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        //public override string ToString() => JsonConvert.SerializeObject(this);

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
