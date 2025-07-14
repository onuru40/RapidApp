using Microsoft.AspNetCore.Mvc;
using RapidApp.Models;
using RapidApp.Services;

namespace RapidApp.Controllers
{
    public class HotelController : Controller
    {
        private readonly IRapidApiService _rapidApiService;

        public HotelController(IRapidApiService rapidApiService)
        {
            _rapidApiService = rapidApiService;
        }

        // Arama formunun bulunduğu sayfa
        public IActionResult Index()
        {
            return View(new SearchHotelsRequest());
        }

        // Otel arama formundan gelen POST isteği
        [HttpPost]
        public async Task<IActionResult> SearchHotels(SearchHotelsRequest request)
        {
            // 1. Konuma göre destinasyonları getir
            var destinations = await _rapidApiService.SearchDestinationsAsync(request.Location);
            var dest = destinations.FirstOrDefault();

            // 2. Destinasyon bulunamadıysa kullanıcıya bildir
            if (dest == null)
            {
                ModelState.AddModelError("", "Girilen konuma ait bir sonuç bulunamadı.");
                return View("Index", request);
            }

            // 3. Arama isteğine dest_id ekle
            request.DestId = dest.dest_id;

            // 4. RapidAPI'den otel listesini getir
            var response = await _rapidApiService.SearchHotelsAsync(request);

            // 5. Otel bulunamadıysa kullanıcıya bildir
            if (response?.data?.hotels == null || !response.data.hotels.Any())
            {
                ModelState.AddModelError("", "Seçilen kriterlerde otel bulunamadı.");
                return View("Index", request);
            }

            // Tarihleri View'a ViewData ile gönderiyoruz
            ViewData["ArrivalDate"] = request.ArrivalDate;
            ViewData["DepartureDate"] = request.DepartureDate;

            // 6. Başarıyla bulunan otelleri göster
            return View("SearchHotels", response); // View: Views/Hotel/SearchHotels.cshtml
        }


        // Otel detay sayfası
        [HttpGet("Hotel/Details/{hotelId}")]
        public async Task<IActionResult> HotelDetails(string hotelId, [FromQuery(Name = "arrival_date")] string arrivalDate, [FromQuery(Name = "departure_date")] string departureDate,
    int adults = 1, string childrenAge = "", int roomQty = 1, string units = "metric", string temperatureUnit = "c", string languageCode = "en-us", string currencyCode = "EUR")
        {
            var hotelDetailResponse = await _rapidApiService.GetHotelDetailsAsync(hotelId, arrivalDate, departureDate, adults, childrenAge, roomQty, units, temperatureUnit, languageCode, currencyCode);

            if (hotelDetailResponse == null)
                return NotFound();

            return View("HotelDetails", hotelDetailResponse);
        }

    }
}
