using BlazorWasm.BurmeseAgriculture.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using static MudBlazor.CategoryTypes;

namespace BlazorWasm.BurmeseAgriculture.Pages
{
    public partial class Home
    {
        private List<AgricultureModel> DataList = new List<AgricultureModel>();
        private AgricultureModel? Data { get; set; }
        private int pageCount = 0;

        [Parameter]
        public string id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            Data = await BurmeseAgricultureService.GetById(id);
            StateHasChanged();
        }

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

        private async Task List(int pageNo = 1, int pageSize = 4)
        {
            var response = await BurmeseAgricultureService.Get(pageNo, pageSize);
            DataList = response.Agricultures;
            pageCount = response.PageCount;
            StateHasChanged();
        }

        private async void PageChanged(int i)
        {
            await List(i);
        }

        private async Task Back()
        {
            Data = null;
            await List();
        }
    }
}
