namespace TestSearchApplication.Models
{
    public class SearchResultItem
    {
        public string? Text { get; set; }
        public double Accuracy { get; set; }
        public int MNO { get; set; }
        public bool IsSequential { get; set; }

    }
}
