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
}
