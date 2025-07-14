namespace RapidApp.Models
{
    public class SearchDestinationResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public List<SearchDestinationData> data { get; set; }
    }

    public class SearchDestinationData
    {
        public string dest_type { get; set; }
        public string cc1 { get; set; }
        public string city_name { get; set; }
        public string label { get; set; }
        public double longitude { get; set; }
        public double latitude { get; set; }
        public string type { get; set; }
        public string region { get; set; }
        public int? city_ufi { get; set; }
        public string name { get; set; }
        public string roundtrip { get; set; }
        public string country { get; set; }
        public string image_url { get; set; }
        public string dest_id { get; set; }
        public int nr_hotels { get; set; }
        public string lc { get; set; }
        public int hotels { get; set; }
    }

    public class SearchHotelsRequest
    {
        public string DestId { get; set; }               // dest_id
        public string SearchType { get; set; }        // search_type, örn: CITY
        public string ArrivalDate { get; set; }       // arrival_date, yyyy-MM-dd
        public string DepartureDate { get; set; }     // departure_date, yyyy-MM-dd
        public int Adults { get; set; }                // adults
        public string ChildrenAge { get; set; }       // children_age, virgülle ayrılmış yaşlar: "5,7"
        public int RoomQty { get; set; }               // room_qty
        public int PageNumber { get; set; }            // page_number
        public string Units { get; set; }              // units, örn: metric
        public string TemperatureUnit { get; set; }   // temperature_unit, örn: c
        public string LanguageCode { get; set; }       // languagecode, örn: en-us
        public string CurrencyCode { get; set; }       // currency_code, örn: AED
        public string Location { get; set; }           // location, örn: US
    }

    public class SearchHotelsResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public SearchHotelsData data { get; set; }
    }

    public class SearchHotelsData
    {
        public Hotel[] hotels { get; set; }
    }

    public class Hotel
    {
        public int id { get; set; }
        public string accessibilityLabel { get; set; }
        public HotelInfo property { get; set; }
    }

    public class HotelInfo
    {
        public string wishlistName { get; set; }
        public int accuratePropertyClass { get; set; }
        public bool isPreferredPlus { get; set; }
        public string checkoutDate { get; set; }
        public float reviewScore { get; set; }
        public string currency { get; set; }
        public string[] blockIds { get; set; }
        public bool isPreferred { get; set; }
        public int optOutFromGalleryChanges { get; set; }
        public string checkinDate { get; set; }
        public string reviewScoreWord { get; set; }
        public int reviewCount { get; set; }
        public int position { get; set; }
        public int ufi { get; set; }
        public float latitude { get; set; }
        public int propertyClass { get; set; }
        public string countryCode { get; set; }
        public float longitude { get; set; }
        public string name { get; set; }
        public bool isFirstPage { get; set; }
        public int qualityClass { get; set; }
        public int mainPhotoId { get; set; }
        public int rankingPosition { get; set; }
        public int id { get; set; }
        public string[] photoUrls { get; set; }
        public bool isClassEstimated { get; set; }
    }

    public class HotelDetailsResponse
    {
        public bool status { get; set; }
        public string message { get; set; }
        public long timestamp { get; set; }
        public HotelDetailsResponseData data { get; set; }
    }

    public class HotelDetailsResponseData
    {
        public int ufi { get; set; }
        public int hotel_id { get; set; }
        public string hotel_name { get; set; }
        public string url { get; set; }
        public string hotel_name_trans { get; set; }
        public int review_nr { get; set; }
        public string arrival_date { get; set; }
        public string departure_date { get; set; }
        public string price_transparency_mode { get; set; }
        public string accommodation_type_name { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string address { get; set; }
        public string address_trans { get; set; }
        public string city { get; set; }
        public string city_trans { get; set; }
        public string city_in_trans { get; set; }
        public string city_name_en { get; set; }
        public string district { get; set; }
        public string countrycode { get; set; }
        public float distance_to_cc { get; set; }
        public int soldout { get; set; }
        public int available_rooms { get; set; }
        public int max_rooms_in_reservation { get; set; }
        public int is_family_friendly { get; set; }
        public int is_closed { get; set; }
        public int is_crimea { get; set; }
        public int is_hotel_ctrip { get; set; }
        public int is_price_transparent { get; set; }
        public int is_genius_deal { get; set; }
        public int is_cash_accepted_check_enabled { get; set; }
        public int qualifies_for_no_cc_reservation { get; set; }
        public int hotel_include_breakfast { get; set; }
    }
}
