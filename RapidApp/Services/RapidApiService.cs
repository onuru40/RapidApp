using Newtonsoft.Json;
using RapidApp.Models;
using System.Text.Json;

namespace RapidApp.Services
{
    public class RapidApiService : IRapidApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiKey;
        private readonly string _apiHost = "booking-com15.p.rapidapi.com";
        private readonly string _baseUrl = "https://booking-com15.p.rapidapi.com/api/v1/hotels";

        public RapidApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiKey = _configuration["RapidAPI:ApiKey"];

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", _apiKey);
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", _apiHost);
        }

        public async Task<List<SearchDestinationData>> SearchDestinationsAsync(string query)
        {
            var url = $"{_baseUrl}/searchDestination?query={Uri.EscapeDataString(query)}";

            using var client = new HttpClient();

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
        {
            { "x-rapidapi-key", "63639f44a8msha901a2b60d6d600p1e38f9jsneb8404f9f71e" },
            { "x-rapidapi-host", "booking-com15.p.rapidapi.com" }
        }
            };

            using var response = await client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var result = System.Text.Json.JsonSerializer.Deserialize<SearchDestinationResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.data ?? new List<SearchDestinationData>();
        }


        public async Task<SearchHotelsResponse> SearchHotelsAsync(SearchHotelsRequest request)
        {
            var url = $"{_baseUrl}/searchHotels?" +
                      $"dest_id={Uri.EscapeDataString(request.DestId)}&" +
                      $"search_type=CITY&" +
                      $"arrival_date={request.ArrivalDate:yyyy-MM-dd}&" +
                      $"departure_date={request.DepartureDate:yyyy-MM-dd}&" +
                      $"adults={request.Adults}&" +
                      $"children_age={Uri.EscapeDataString(request.ChildrenAge)}&" +
                      $"page_number=1&" +
                      $"units=metric&" +
                      $"temperature_unit=c&" +
                      $"languagecode=en-us&" +
                      $"currency_code=TRY";

            using var client = new HttpClient();

            var requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url),
                Headers =
        {
            { "x-rapidapi-key", "63639f44a8msha901a2b60d6d600p1e38f9jsneb8404f9f71e" },
            { "x-rapidapi-host", "booking-com15.p.rapidapi.com" }
        }
            };

            using var response = await client.SendAsync(requestMessage);
            response.EnsureSuccessStatusCode();

            var body = await response.Content.ReadAsStringAsync();

            // Json.NET kullanıyorsan:
            var values = JsonConvert.DeserializeObject<SearchHotelsResponse>(body);

            // Eğer values.result yoksa, doğrudan values dön ya da values.data.hotels’a bak
            // Burada result mu, data mı doğru alan? JSON cevabına göre değişir.
            // Örnek JSON yapısına göre:
            // return values?.data ?? new SearchHotelsData();

            return values ?? new SearchHotelsResponse();
        }

        public async Task<HotelDetailsResponse> GetHotelDetailsAsync(string hotelId, string arrivalDate, string departureDate, int adults = 1, string childrenAge = "", int roomQty = 1, string units = "metric", string temperatureUnit = "c", string languageCode = "en-us", string currencyCode = "EUR")
        {
            var url = $"{_baseUrl}/getHotelDetails?" +
                $"hotel_id={Uri.EscapeDataString(hotelId)}" +
                $"&arrival_date={Uri.EscapeDataString(arrivalDate)}" +
                $"&departure_date={Uri.EscapeDataString(departureDate)}" +
                $"&adults={adults}" +
                $"&children_age={Uri.EscapeDataString(childrenAge)}" +
                $"&room_qty={roomQty}" +
                $"&units={Uri.EscapeDataString(units)}" +
                $"&temperature_unit={Uri.EscapeDataString(temperatureUnit)}" +
                $"&languagecode={Uri.EscapeDataString(languageCode)}" +
                $"&currency_code={Uri.EscapeDataString(currencyCode)}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = System.Text.Json.JsonSerializer.Deserialize<HotelDetailsResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result;
        }
    }
}
