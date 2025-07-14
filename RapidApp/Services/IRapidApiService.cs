using RapidApp.Models;

namespace RapidApp.Services
{
    public interface IRapidApiService
    {
        Task<List<SearchDestinationData>> SearchDestinationsAsync(string query);
        Task<SearchHotelsResponse> SearchHotelsAsync(SearchHotelsRequest request);
        Task<HotelDetailsResponse> GetHotelDetailsAsync(string hotelId, string arrivalDate, string departureDate, int adults = 1, string childrenAge = "", int roomQty = 1, string units = "metric", string temperatureUnit = "c", string languageCode = "en-us", string currencyCode = "EUR");
    }
}
