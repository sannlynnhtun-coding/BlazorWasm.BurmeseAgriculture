using BlazorWasm.BurmeseAgriculture.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace BlazorWasm.BurmeseAgriculture.Services
{
    public class BurmeseAgricultureService
    {
        public static List<AgricultureModel>? Agricultures = null;

        private readonly HttpClient _httpClient;

        public BurmeseAgricultureService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AgricultureResponseModel> Get(int pageNo = 1, int pageSize = 4)
        {
            var response = await DataAsync();
            int pageCount = response.Count / pageSize;
            if (response.Count % pageSize > 0)
                pageCount++;

            AgricultureResponseModel model = new AgricultureResponseModel()
            {
                PageNo = pageNo,
                PageSize = pageSize,
                PageCount = pageCount,
                Agricultures = response.Skip((pageNo - 1) * pageSize).Take(pageSize).ToList()
            };

            return model;
        }

        private async Task<List<AgricultureModel>> DataAsync()
        {
            if (Agricultures is not null) return Agricultures;
            Agricultures = await _httpClient.GetFromJsonAsync<List<AgricultureModel>>("data/BurmeseAgriculture.json");
            return Agricultures!;
        }
    }
}
