namespace HotelListingAPI.Models
{
    public class RequestParams
    {
        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int defaultPageSize = 10;

        public int PageSize
        {
            get
            {
                return defaultPageSize;
            }

            set
            {
                defaultPageSize = value > maxPageSize ? defaultPageSize : value;
            }
        }
    }
}
