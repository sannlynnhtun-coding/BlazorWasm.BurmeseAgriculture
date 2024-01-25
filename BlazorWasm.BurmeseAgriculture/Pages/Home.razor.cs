using BlazorWasm.BurmeseAgriculture.Models;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace BlazorWasm.BurmeseAgriculture.Pages
{
    public partial class Home
    {
        private List<AgricultureModel> DataList = new List<AgricultureModel>();

        private async Task LoadJavaScript()
        {
            await Task.Delay(1000);
            await JsRuntime.InvokeVoidAsync("loadJs", new string[]
            {
                "assets/js/main.js"
            }.ToList());
            await List();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadJavaScript();
            }
        }

        private async Task List()
        {
            var response = await httpClient.GetFromJsonAsync<List<AgricultureModel>>("data/BurmeseAgriculture.json");
            DataList = response!;
            Console.WriteLine(JsonConvert.SerializeObject(DataList, Formatting.Indented));
        }
    }
}
