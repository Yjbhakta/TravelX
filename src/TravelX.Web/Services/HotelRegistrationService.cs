using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace TravelX.Web.Services
{
    public class HotelRegistrationService
    {
        private readonly HttpClient _httpClient;

        public HotelRegistrationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RegistrationResult> RegisterHotelAsync(HotelRegistrationDto registration)
        {
            try
            {
                // In a real app, this would call your API endpoint
                // For now, we'll simulate the registration
                await Task.Delay(1000); // Simulate API call
                
                return new RegistrationResult
                {
                    Success = true,
                    HotelId = new Random().Next(1000, 9999),
                    OwnerId = new Random().Next(1000, 9999),
                    RegistrationId = new Random().Next(1000, 9999)
                };
            }
            catch (Exception ex)
            {
                return new RegistrationResult
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }
        }

        public async Task<int> GetTotalHotelCountAsync()
        {
            // For Blazor WebAssembly, use in-memory count or API call
            return await Task.FromResult(2473 + new Random().Next(0, 50));
        }

        public async Task<int> GetTodayRegistrationsAsync()
        {
            return await Task.FromResult(12 + new Random().Next(0, 8));
        }

        public async Task<HotelStats> GetHotelStatsAsync()
        {
            var total = await GetTotalHotelCountAsync();
            var today = await GetTodayRegistrationsAsync();
            
            return new HotelStats
            {
                TotalHotels = total,
                TodayRegistrations = today,
                ThisWeekRegistrations = today + new Random().Next(15, 45),
                ThisMonthRegistrations = today + new Random().Next(100, 300)
            };
        }

        private double CalculateInitialContributionScore(string roomCount)
        {
            return roomCount switch
            {
                "1-10" => 1.0,
                "11-50" => 2.5,
                "51-100" => 5.0,
                "101-250" => 10.0,
                "251-500" => 20.0,
                "500+" => 35.0,
                _ => 1.0
            };
        }
    }

    public class HotelRegistrationDto
    {
        public string HotelName { get; set; } = string.Empty;
        public string RoomCount { get; set; } = string.Empty;
        public string HotelCategory { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string? Description { get; set; }
    }

    public class RegistrationResult
    {
        public bool Success { get; set; }
        public int HotelId { get; set; }
        public int OwnerId { get; set; }
        public int RegistrationId { get; set; }
        public string? ErrorMessage { get; set; }
    }

    public class HotelStats
    {
        public int TotalHotels { get; set; }
        public int TodayRegistrations { get; set; }
        public int ThisWeekRegistrations { get; set; }
        public int ThisMonthRegistrations { get; set; }
    }
}