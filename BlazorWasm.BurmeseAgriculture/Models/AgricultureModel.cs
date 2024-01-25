namespace BlazorWasm.BurmeseAgriculture.Models
{
    public record AgricultureModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
    }

    public class AgricultureResponseModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public int PageCount { get; set; }
        public List<AgricultureModel> Agricultures { get; set; }
    }
}
